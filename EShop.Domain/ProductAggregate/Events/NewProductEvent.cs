using EShop.Domain.Abstractions;
using EShop.Domain.CategoryAggregate;

namespace EShop.Domain.ProductAggregate.Events;

public class NewProductEvent(Product product, Category category) : IDomainEvent
{
    public Product Product { get; } = product;
    public Category Category { get; } = category;
}