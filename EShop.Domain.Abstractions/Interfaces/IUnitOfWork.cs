using EShop.Domain.Abstractions.Repositories;

namespace EShop.Domain.Abstractions.Interfaces;

public interface IUnitOfWork
{
    Lazy<IUserRepository> UserRepository { get; }
    Lazy<IProductRepository> ProductRepository { get; }
    Lazy<IOrderRepository> OrderRepository { get; }
    Lazy<ICategoryRepository> CategoryRepository { get; }
    Task SaveChangesAsync();
}