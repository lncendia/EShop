using EShop.Domain.Abstractions;
using EShop.Domain.Extensions;
using EShop.Domain.OrderAggregate.ValueObjects;
using EShop.Domain.ProductAggregate;
using EShop.Domain.UserAggregate;

namespace EShop.Domain.OrderAggregate;

public class Order : AggregateRoot
{
    private const int MaxMessageLength = 500;
    
    public required IReadOnlyCollection<Product> Products
    {
        init
        {
            if (value.Count == 0) throw new ArgumentException("Products collection can't be empty");
            TotalPrice = value.Sum(p => p.Price * p.Count);

            OrderItems = value.Select(p => new ProductInfo
            {
                Id = p.Id,
                Count = p.Count
            }).ToArray();
        }
    }

    public required User User
    {
        init => UserId = value.Id;
    }

    public required CustomerInfo CustomerInfo { get; init; }
    public required DeliveryInfo DeliveryInfo { get; init; }

    public Guid UserId { get; private set; }
    public decimal TotalPrice { get; private init; }
    public DateTime CreationTime { get; } = DateTime.UtcNow;
    public bool IsCompleted { get; private set; }
    public bool? IsSucceeded { get; private set; }
    public string? Message { get; private set; }
    public IReadOnlyCollection<ProductInfo> OrderItems { get; private init; } = null!;

    public void Complete(bool succeeded, string? message)
    {
        IsCompleted = true;
        IsSucceeded = succeeded;
        Message = message?.ValidateLength(MaxMessageLength);
    }
}