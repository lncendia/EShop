using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Product;
using EShop.Application.Storage.Visitors.Sorting;
using EShop.Application.Storage.Visitors.Specifications;
using EShop.Domain.Abstractions.Repositories;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Ordering.Visitor;
using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Repositories;

public class ProductRepository(
    ApplicationDbContext context,
    IAggregateMapperUnit<Product, ProductModel> aggregateMapper,
    IModelMapperUnit<ProductModel, Product> modelMapper)
    : IProductRepository
{
    public async Task AddAsync(Product entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        var playlist = await modelMapper.MapAsync(entity);
        await context.AddAsync(playlist);
    }

    public async Task UpdateAsync(Product entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        await modelMapper.MapAsync(entity);
    }
    

    public Task DeleteAsync(Guid id)
    {
        context.Remove(context.Products.First(playlist => playlist.Id == id));
        return Task.CompletedTask;
    }

    public async Task<Product?> GetAsync(Guid id)
    {
        var playlist = await context.Products
            .LoadDependencies()
            .AsNoTracking()
            .FirstOrDefaultAsync(playlistModel => playlistModel.Id == id);
        
        return playlist == null ? null : aggregateMapper.Map(playlist);
    }

    public async Task<IReadOnlyCollection<Product>> FindAsync(
        ISpecification<Product, IProductSpecificationVisitor>? specification,
        IOrderBy<Product, IProductSortingVisitor>? orderBy = null, int? skip = null, int? take = null)
    {
        var query = context.Products.LoadDependencies().AsQueryable();
        if (specification != null)
        {
            var visitor = new ProductVisitor();
            specification.Accept(visitor);
            if (visitor.Expr != null) query = query.Where(visitor.Expr);
        }

        if (orderBy != null)
        {
            var visitor = new ProductSortingVisitor();
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
        
        var models = await query
            .LoadDependencies()
            .AsNoTracking()
            .ToArrayAsync();

        return models.Select(aggregateMapper.Map).ToArray();
    }

    public Task<int> CountAsync(ISpecification<Product, IProductSpecificationVisitor>? specification)
    {
        var query = context.Products.AsQueryable();
        if (specification == null) return query.CountAsync();
        var visitor = new ProductVisitor();
        specification.Accept(visitor);
        if (visitor.Expr != null) query = query.Where(visitor.Expr);

        return query.CountAsync();
    }
}