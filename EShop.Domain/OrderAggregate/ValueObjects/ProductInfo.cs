namespace EShop.Domain.OrderAggregate.ValueObjects;

public class ProductInfo
{
    public required Guid Id { get; init; } 
    public required int Count { get; init; }
}

