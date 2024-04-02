namespace EShop.Domain.OrderAggregate.Events;

public class OrderCompletedSuccessfullyEvent
{
    public required IEnumerable<Guid> Products { get; init; }
}