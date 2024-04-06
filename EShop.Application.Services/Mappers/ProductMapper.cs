using EShop.Application.Abstractions.DTOs.Products;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.ProductAggregate;
using EShop.Domain.UserAggregate;

namespace EShop.Application.Services.Mappers;

internal static class ProductMapper
{
    public static ProductDto Map(Product product, Category category, User? user) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl,
        Name = product.Name,
        Price = product.Price,
        Attributes = product.Attributes,
        Count = product.Count,
        CategoryId = product.CategoryId,
        CategoryName = category.Name,
        InFavorite = user?.Favorites.Any(f => f == product.Id) ?? false,
        InShoppingCart = user?.ShoppingCart.Any(c => c.Id == product.Id) ?? false,
        Description = product.Description
    };
}