using EShop.Domain.Abstractions;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.Extensions;
using EShop.Domain.ProductAggregate.Events;
using EShop.Domain.ProductAggregate.Exceptions;

namespace EShop.Domain.ProductAggregate;

public class Product : AggregateRoot
{
    private const int MaxNameLength = 50;

    private string _name = null!;
    private decimal _cost;
    private int _count;

    public Product(Category category, IReadOnlyDictionary<string, string> attributes)
    {
        if (category.Attributes.Any(r => attributes.Keys.All(a => a != r.Name)))
            throw new NoProductRequiredAttributesException();

        CategoryId = category.Id;
        Attributes = attributes;
        AddDomainEvent(new NewProductEvent(this, category));
    }

    public required Uri PhotoUrl { get; init; }

    public IReadOnlyDictionary<string, string> Attributes { get; }

    public Guid CategoryId { get; }

    public required string Name
    {
        get => _name;
        set => _name = value.ValidateLength(MaxNameLength);
    }

    public required decimal Price
    {
        get => _cost;
        set
        {
            if (value <= 0) throw new IncorrectProductPriceException();
            _cost = value;
        }
    }

    public int Count
    {
        get => _count;
        set
        {
            if (value <= 0) throw new IncorrectProductCountException();
            _count = value;
        }
    }
}