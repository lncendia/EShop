namespace EShop.Domain.CategoryAggregate.ValueObjects;

public class AttributeValue
{
    public required string Value { get; init; }
    public required int Count { get; init; }

    public AttributeValue Increment() => new()
    {
        Value = Value,
        Count = Count + 1
    };

    public AttributeValue Decrement() => new()
    {
        Value = Value,
        Count = Count - 1
    };
}