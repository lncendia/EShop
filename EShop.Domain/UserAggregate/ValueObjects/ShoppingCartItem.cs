namespace EShop.Domain.UserAggregate.ValueObjects;

public class ShoppingCartItem
{
    public required Guid Id { get; init; } 
    public required int Count { get; init; }
}

