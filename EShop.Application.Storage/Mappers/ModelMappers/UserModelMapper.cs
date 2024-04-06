using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.User;
using EShop.Domain.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Mappers.ModelMappers;

internal class UserModelMapper(ApplicationDbContext context) : IModelMapperUnit<UserModel, User>
{
    public async Task<UserModel> MapAsync(User aggregate)
    {
        var model = await context.Users
            .LoadDependencies()
            .FirstOrDefaultAsync(x => x.Id == aggregate.Id) ?? new UserModel { Id = aggregate.Id };

        ProcessFavorites(aggregate, model);

        ProcessShoppingCart(aggregate, model);

        return model;
    }

    private static void ProcessFavorites(User aggregate, UserModel model)
    {
        model.Favorites.RemoveAll(uh => aggregate.Favorites.All(eh => eh != uh.ProductId));

        var favoritesToAdd = aggregate.Favorites
            .Where(eh => model.Favorites.All(uh => uh.ProductId != eh))
            .Select(eh => new FavoriteItemModel { ProductId = eh });

        model.Favorites.AddRange(favoritesToAdd);
    }

    private static void ProcessShoppingCart(User aggregate, UserModel model)
    {
        model.ShoppingCart.RemoveAll(uh => aggregate.ShoppingCart.All(eh => eh.Id != uh.ProductId));

        var shoppingCartToAdd = aggregate.ShoppingCart
            .Where(eh => model.ShoppingCart.All(uh => uh.ProductId != eh.Id))
            .Select(eh => new ShoppingCartItemModel { ProductId = eh.Id, Count = eh.Count });

        foreach (var value in model.ShoppingCart)
        {
            value.Count = aggregate.ShoppingCart.First(i => i.Id == value.ProductId).Count;
        }

        model.ShoppingCart.AddRange(shoppingCartToAdd);
    }
}