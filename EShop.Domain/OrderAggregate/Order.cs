using EShop.Domain.Abstractions;
using EShop.Domain.Extensions;
using EShop.Domain.OrderAggregate.Events;
using EShop.Domain.OrderAggregate.Exceptions;
using EShop.Domain.OrderAggregate.ValueObjects;
using EShop.Domain.ProductAggregate;
using EShop.Domain.UserAggregate;

namespace EShop.Domain.OrderAggregate;

public class Order : AggregateRoot
{
    private const int MaxMessageLength = 500;

    public Order(IReadOnlyCollection<(Product product, int count)> products, User user)
    {
        if (products.Count == 0) throw new ArgumentException("Products collection can't be empty");
        foreach (var (product, count) in products)
        {
            if (product.Count < count) throw new NotEnoughProductsException(product.Id, product.Name, product.Count);
        }

        TotalPrice = products.Sum(p => p.product.Price * p.count);
        OrderItems = products.Select(p => new ProductInfo
        {
            Id = p.product.Id,
            Count = p.count
        }).ToArray();
        UserId = user.Id;
        AddDomainEvent(new OrderCreatedEvent { Products = products });
    }

    public required CustomerInfo CustomerInfo { get; init; }
    public required DeliveryInfo DeliveryInfo { get; init; }

    public Guid UserId { get; private set; }
    public decimal TotalPrice { get; private init; }
    public DateTime CreationTime { get; } = DateTime.UtcNow;
    public bool IsCompleted { get; private set; }
    public bool? IsSucceeded { get; private set; }
    public string? Message { get; private set; }
    public IReadOnlyCollection<ProductInfo> OrderItems { get; private init; }

    public void Complete(bool succeeded, string? message)
    {
        if (!succeeded)
            AddDomainEvent(new OrderCanceledEvent { Products = OrderItems.Select(i => (i.Id, i.Count)).ToArray() });
        IsCompleted = true;
        IsSucceeded = succeeded;
        Message = message?.ValidateLength(MaxMessageLength);
    }
}