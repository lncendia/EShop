using EShop.Application.Storage.Context;
using EShop.Application.Storage.Mappers.AggregateMappers;
using EShop.Application.Storage.Mappers.ModelMappers;
using EShop.Application.Storage.Repositories;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.Abstractions.Repositories;
using MediatR;

namespace EShop.Application.Storage;

public class UnitOfWork : IUnitOfWork
{
    private readonly ApplicationDbContext _context;
    private readonly IMediator _mediator;

    public UnitOfWork(ApplicationDbContext context, IMediator mediator)
    {
        _context = context;
        _mediator = mediator;
        
        UserRepository = new Lazy<IUserRepository>(() =>
            new UserRepository(_context, new UserMapper(), new UserModelMapper(_context)));
        
        ProductRepository = new Lazy<IProductRepository>(() =>
            new ProductRepository(_context, new ProductMapper(), new ProductModelMapper(_context)));
        
        OrderRepository = new Lazy<IOrderRepository>(() =>
            new OrderRepository(_context, new OrderMapper(), new OrderModelMapper(_context)));
        
        CategoryRepository = new Lazy<ICategoryRepository>(() =>
            new CategoryRepository(_context, new CategoryMapper(), new CategoryModelMapper(_context)));
    }

    public Lazy<IUserRepository> UserRepository { get; }
    public Lazy<IProductRepository> ProductRepository { get; }
    public Lazy<IOrderRepository> OrderRepository { get; }
    public Lazy<ICategoryRepository> CategoryRepository { get; }
    

    public async Task SaveChangesAsync()
    {
        foreach (var notification in _context.Notifications.ToList())
        {
            await _mediator.Publish(notification);
        }
        
        await _context.SaveChangesAsync();
    }
}