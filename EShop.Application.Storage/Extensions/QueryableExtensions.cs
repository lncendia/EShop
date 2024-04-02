using EShop.Application.Storage.Models.Category;
using EShop.Application.Storage.Models.Order;
using EShop.Application.Storage.Models.Product;
using EShop.Application.Storage.Models.User;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Extensions;

public static class QueryableExtensions
{
    public static IQueryable<UserModel> LoadDependencies(this IQueryable<UserModel> queryable)
    {
        return queryable
            .Include(u => u.Favorites)
            .Include(u => u.ShoppingCart);
    }

    public static IQueryable<ProductModel> LoadDependencies(this IQueryable<ProductModel> queryable)
    {
        return queryable.Include(p => p.Attributes);
    }
    
    public static IQueryable<OrderModel> LoadDependencies(this IQueryable<OrderModel> queryable)
    {
        return queryable.Include(o => o.OrderItems);
    }

    public static IQueryable<CategoryModel> LoadDependencies(this IQueryable<CategoryModel> queryable)
    {
        return queryable
            .Include(c=>c.Attributes)
            .ThenInclude(a=>a.Values);
    }
}