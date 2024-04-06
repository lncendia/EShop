using EShop.Application.Abstractions.Commands.Profile;
using EShop.Application.Abstractions.DTOs.Profile;
using EShop.Application.Abstractions.Queries.Profile;
using EShop.Application.Web.Common.Enums;
using EShop.Application.Web.Profile.InputModels;
using EShop.Application.Web.Profile.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Application.Web.Profile.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
[Authorize]
public class ProfileController(ISender sender) : ControllerBase
{
    [HttpPost]
    public async Task AddToFavorite(ProductInputModel model)
    {
        await sender.Send(new AddToFavoriteCommand
        {
            ProductId = model.Id,
            UserId = User.Id()
        });
    }

    [HttpPost]
    public async Task AddToShoppingCart(ShoppingCartInputModel model)
    {
        await sender.Send(new AddToShoppingCartCommand
        {
            ProductId = model.Id,
            UserId = User.Id(),
            Count = model.Count
        });
    }

    [HttpPost]
    public async Task RemoveFromFavorite(ProductInputModel model)
    {
        await sender.Send(new RemoveFromFavoriteCommand
        {
            ProductId = model.Id,
            UserId = User.Id()
        });
    }

    [HttpPost]
    public async Task RemoveFromShoppingCart(ProductInputModel model)
    {
        await sender.Send(new RemoveFromShoppingCartCommand
        {
            ProductId = model.Id,
            UserId = User.Id()
        });
    }

    [HttpGet]
    public async Task<IEnumerable<UserProductViewModel>> Favorite()
    {
        var products = await sender.Send(new UserFavoritesQuery { UserId = User.Id() });
        return products.Select(Map);
    }

    [HttpGet]
    public async Task<IEnumerable<UserProductCountViewModel>> ShoppingCart()
    {
        var products = await sender.Send(new UserShoppingCartQuery { UserId = User.Id() });
        return products.Select(Map);
    }

    private UserProductViewModel Map(UserProductDto product) => new()
    {
        Id = product.Id,
        PhotoUrl = $"{Request.Scheme}://{Request.Host}/{product.PhotoUrl.ToString().Replace('\\', '/')}",
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        CategoryName = product.CategoryName,
        CountType = GetCountType(product.AvailableCount),
    };

    private UserProductCountViewModel Map(UserProductCountDto product) => new()
    {
        Id = product.Id,
        PhotoUrl = $"{Request.Scheme}://{Request.Host}/{product.PhotoUrl.ToString().Replace('\\', '/')}",
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        CategoryName = product.CategoryName,
        CountType = GetCountType(product.AvailableCount),
        Count = product.Count
    };

    private static CountType GetCountType(int count)
    {
        return count switch
        {
            > 10 => CountType.Available,
            > 0 => CountType.Close,
            _ => CountType.OutOfStock
        };
    }
}