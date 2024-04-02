using System.Reflection;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Mappers.StaticMethods;
using EShop.Application.Storage.Models.User;
using EShop.Domain.UserAggregate;

namespace EShop.Application.Storage.Mappers.AggregateMappers;

internal class UserMapper : IAggregateMapperUnit<User, UserModel>
{
    private static readonly Type UserType = typeof(User);

    private static readonly FieldInfo ShoppingCart =
        UserType.GetField("_shoppingCart", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo Favorites =
        UserType.GetField("_favorites", BindingFlags.Instance | BindingFlags.NonPublic)!;


    public User Map(UserModel model)
    {
        var user = new User();

        var favorites = model.Favorites
            .Select(x => x.ProductId)
            .ToList();

        var shoppingCart = model.ShoppingCart
            .Select(x => x.ProductId)
            .ToList();

        ShoppingCart.SetValue(user, shoppingCart);
        Favorites.SetValue(user, favorites);

        IdFields.AggregateId.SetValue(user, model.Id);

        return user;
    }
}