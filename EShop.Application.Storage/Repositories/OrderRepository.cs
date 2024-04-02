using EShop.Application.Storage.Context;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Order;
using EShop.Application.Storage.Visitors.Sorting;
using EShop.Application.Storage.Visitors.Specifications;
using EShop.Domain.Abstractions.Repositories;
using EShop.Domain.OrderAggregate;
using EShop.Domain.OrderAggregate.Ordering.Visitor;
using EShop.Domain.OrderAggregate.Specifications.Visitor;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.Specifications.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Repositories;

public class OrderRepository(
    ApplicationDbContext context,
    IAggregateMapperUnit<Order, OrderModel> aggregateMapper,
    IModelMapperUnit<OrderModel, Order> modelMapper)
    : IOrderRepository
{
    public async Task AddAsync(Order entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        var room = await modelMapper.MapAsync(entity);
        await context.AddAsync(room);
    }

    public async Task UpdateAsync(Order entity)
    {
        context.Notifications.AddRange(entity.DomainEvents);
        await modelMapper.MapAsync(entity);
    }

    public Task DeleteAsync(Guid id)
    {
        context.Remove(context.Orders.First(room => room.Id == id));
        return Task.CompletedTask;
    }

    public async Task<Order?> GetAsync(Guid id)
    {
        var room = await context.Orders.AsNoTracking().FirstOrDefaultAsync(youtubeOrderModel => youtubeOrderModel.Id == id);
        return room == null ? null : aggregateMapper.Map(room);
    }

    public async Task<IReadOnlyCollection<Order>> FindAsync(
        ISpecification<Order, IOrderSpecificationVisitor>? specification,
        IOrderBy<Order, IOrderSortingVisitor>? orderBy = null, int? skip = null,
        int? take = null)
    {
        var query = context.Orders.AsQueryable();
        if (specification != null)
        {
            var visitor = new OrderVisitor();
            specification.Accept(visitor);
            if (visitor.Expr != null) query = query.Where(visitor.Expr);
        }

        if (orderBy != null)
        {
            var visitor = new OrderSortingVisitor();
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

        var models = await query.AsNoTracking().ToArrayAsync();
        return models.Select(aggregateMapper.Map).ToArray();
    }

    public Task<int> CountAsync(ISpecification<Order, IOrderSpecificationVisitor>? specification)
    {
        var query = context.Orders.AsQueryable();
        if (specification == null) return query.CountAsync();
        var visitor = new OrderVisitor();
        specification.Accept(visitor);
        if (visitor.Expr != null) query = query.Where(visitor.Expr);

        return query.CountAsync();
    }
}