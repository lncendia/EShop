using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Category;
using EShop.Application.Storage.Visitors.Sorting;
using EShop.Application.Storage.Visitors.Specifications;
using EShop.Domain.Abstractions.Repositories;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.CategoryAggregate.Ordering.Visitor;
using EShop.Domain.CategoryAggregate.Specifications.Visitor;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.Specifications.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Repositories;

public class CategoryRepository(
    ApplicationDbContext context,
    IAggregateMapperUnit<Category, CategoryModel> aggregateMapper,
    IModelMapperUnit<CategoryModel, Category> modelMapper)
    : ICategoryRepository
{
    public async Task AddAsync(Category entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        var rating = await modelMapper.MapAsync(entity);
        await context.AddAsync(rating);
    }

    public async Task UpdateAsync(Category entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        await modelMapper.MapAsync(entity);
    }
    

    public Task DeleteAsync(Guid id)
    {
        context.Remove(context.Categories.First(rating => rating.Id ==id));
        return Task.CompletedTask;
    }

    public async Task<Category?> GetAsync(Guid id)
    {
        var rating = await context.Categories
            .LoadDependencies()
            .AsNoTracking()
            .FirstOrDefaultAsync(ratingModel => ratingModel.Id == id);
        return rating == null ? null : aggregateMapper.Map(rating);
    }

    public async Task<IReadOnlyCollection<Category>> FindAsync(
        ISpecification<Category, ICategorySpecificationVisitor>? specification,
        IOrderBy<Category, ICategorySortingVisitor>? orderBy = null, int? skip = null, int? take = null)
    {
        var query = context.Categories.LoadDependencies().AsQueryable();
        if (specification != null)
        {
            var visitor = new CategoryVisitor();
            specification.Accept(visitor);
            if (visitor.Expr != null) query = query.Where(visitor.Expr);
        }

        if (orderBy != null)
        {
            var visitor = new CategorySortingVisitor();
            orderBy.Accept(visitor);
            var firstQuery = visitor.SortItems.First();
            var orderedQuery = firstQuery.IsDescending
                ? query.OrderByDescending(firstQuery.Expr)
                : query.OrderBy(firstQuery.Expr);

            orderedQuery = visitor.SortItems.Skip(1)
                .Aggregate(orderedQuery, (current, sort) => sort.IsDescending
                    ? current.ThenByDescending(sort.Expr)
                    : current.ThenBy(sort.Expr));
            
            query = orderedQuery.ThenBy(v => v.Id);
        }
        else
        {
            query = query.OrderBy(x => x.Id);
        }

        if (skip.HasValue) query = query.Skip(skip.Value);
        if (take.HasValue) query = query.Take(take.Value);

        return (await query.AsNoTracking().ToArrayAsync()).Select(aggregateMapper.Map).ToArray();
    }

    public Task<int> CountAsync(ISpecification<Category, ICategorySpecificationVisitor>? specification)
    {
        var query = context.Categories.AsQueryable();
        if (specification == null) return query.CountAsync();
        var visitor = new CategoryVisitor();
        specification.Accept(visitor);
        if (visitor.Expr != null) query = query.Where(visitor.Expr);

        return query.CountAsync();
    }
}