using EShop.Domain.Abstractions;
using EShop.Domain.ProductAggregate;
using EShop.Domain.UserAggregate.ValueObjects;

namespace EShop.Domain.UserAggregate;

public class User(Guid id) : AggregateRoot
{
    private readonly List<ShoppingCartItem> _shoppingCart = [];
    private readonly List<Guid> _favorites = [];

    public override Guid Id { get; } = id;

    public IReadOnlyCollection<ShoppingCartItem> ShoppingCart => _shoppingCart.AsReadOnly();
    public IReadOnlyCollection<Guid> Favorites => _favorites.AsReadOnly();

    public void AddToShoppingCart(Product product, int count)
    {
        if (count is < 1 or > 255) throw new ArgumentException("Count let be grater then 0 and less then 255");
        _shoppingCart.RemoveAll(i => i.Id == product.Id);
        if (_shoppingCart.Count >= 50) throw new NotImplementedException();
        _shoppingCart.Add(new ShoppingCartItem { Id = product.Id, Count = count });
    }

    public void AddToFavorite(Product product)
    {
        _favorites.RemoveAll(i => i == product.Id);
        if (_favorites.Count >= 50) throw new NotImplementedException();
        _favorites.Add(product.Id);
    }

    public void RemoveFromShoppingCart(Guid product) => _shoppingCart.RemoveAll(i => i.Id == product);

    public void RemoveFromFavorite(Guid product) => _favorites.Remove(product);
}