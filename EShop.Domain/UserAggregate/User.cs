using EShop.Domain.Abstractions;
using EShop.Domain.ProductAggregate;

namespace EShop.Domain.UserAggregate;

public class User : AggregateRoot
{
    private readonly List<Guid> _shoppingCart = [];
    private readonly List<Guid> _favorites = [];

    public IReadOnlyCollection<Guid> ShoppingCart => _shoppingCart.AsReadOnly();
    public IReadOnlyCollection<Guid> Favorites => _favorites.AsReadOnly();

    public void AddToShoppingCart(Product product)
    {
        if (_shoppingCart.Count >= 100) throw new Exception();
        _shoppingCart.Add(product.Id);
    }

    public void AddToFavorite(Product product)
    {
        if (_favorites.Count >= 100) throw new Exception();
        _favorites.Add(product.Id);
    }

    public bool RemoveFromShoppingCart(Guid product) => _shoppingCart.Remove(product);

    public bool RemoveFromFavorite(Guid product) => _favorites.Remove(product);
}