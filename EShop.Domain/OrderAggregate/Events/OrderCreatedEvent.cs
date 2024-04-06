using EShop.Domain.Abstractions;
using EShop.Domain.ProductAggregate;

namespace EShop.Domain.OrderAggregate.Events;

public class OrderCreatedEvent : IDomainEvent
{
    public required IReadOnlyCollection<(Product product, int count)> Products { get; init; }
}