namespace EShop.Domain.OrderAggregate.Exceptions;

public class NotEnoughProductsException(Guid id, string name, int available)
    : Exception($"There is not enough product {name}. Available {available}")
{
    public Guid Id { get; } = id;
    public string Name { get; } = name;
    public int Available { get; } = available;
}