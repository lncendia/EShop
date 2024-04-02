using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.User;
using EShop.Application.Storage.Visitors.Sorting;
using EShop.Application.Storage.Visitors.Specifications;
using EShop.Domain.Abstractions.Repositories;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.Specifications.Abstractions;
using EShop.Domain.UserAggregate;
using EShop.Domain.UserAggregate.Ordering.Visitor;
using EShop.Domain.UserAggregate.Specifications.Visitor;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Repositories;

public class UserRepository(
    ApplicationDbContext context,
    IAggregateMapperUnit<User, UserModel> aggregateMapper,
    IModelMapperUnit<UserModel, User> modelMapper)
    : IUserRepository
{
    public async Task AddAsync(User entity)
    {
        var user = await modelMapper.MapAsync(entity);
        context.Notifications.AddRange(entity.DomainEvents);
        await context.AddAsync(user);
    }

    public async Task UpdateAsync(User entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        await modelMapper.MapAsync(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        context.Remove(context.Users.First(user => user.Id == id));
        return Task.CompletedTask;
    }

    public async Task<User?> GetAsync(Guid id)
    {
        var user = await context.Users
            .LoadDependencies()
            .AsNoTracking()
            .FirstOrDefaultAsync(userModel => userModel.Id == id);
        
        return user == null ? null : aggregateMapper.Map(user);
    }

    public async Task<IReadOnlyCollection<User>> FindAsync(
        ISpecification<User, IUserSpecificationVisitor>? specification,
        IOrderBy<User, IUserSortingVisitor>? orderBy = null, int? skip = null, int? take = null)
    {
        var query = context.Users.AsQueryable();
        if (specification != null)
        {
            var visitor = new UserVisitor();
            specification.Accept(visitor);
            if (visitor.Expr != null) query = query.Where(visitor.Expr);
        }

        if (orderBy != null)
        {
            var visitor = new UserSortingVisitor();
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

    public Task<int> CountAsync(ISpecification<User, IUserSpecificationVisitor>? specification)
    {
        var query = context.Users.AsQueryable();
        if (specification == null) return query.CountAsync();
        var visitor = new UserVisitor();
        specification.Accept(visitor);
        if (visitor.Expr != null) query = query.Where(visitor.Expr);

        return query.CountAsync();
    }
}