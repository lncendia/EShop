using EShop.Application.Abstractions.DTOs.Profile;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.ProductAggregate;

namespace EShop.Application.Services.Mappers;

internal static class ProfileMapper
{
    public static UserProductDto Map(Product product, Category category) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl,
        Name = product.Name,
        Price = product.Price,
        CategoryName = category.Name,
        Description = product.Description,
        AvailableCount = product.Count
    };

    public static UserProductCountDto Map(Product product, Category category, int count) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl,
        Name = product.Name,
        Price = product.Price,
        CategoryName = category.Name,
        Description = product.Description,
        Count = count,
        AvailableCount = product.Count
    };
}