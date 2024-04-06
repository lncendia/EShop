using EShop.Domain.Abstractions;

namespace EShop.Domain.OrderAggregate.Events;

public class OrderCanceledEvent : IDomainEvent
{
    public required IReadOnlyCollection<(Guid product, int count)> Products { get; init; }
}