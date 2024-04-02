using EShop.Domain.Abstractions;
using EShop.Domain.Extensions;
using EShop.Domain.ProductAggregate;
using Attribute = EShop.Domain.CategoryAggregate.Entities.Attribute;

namespace EShop.Domain.CategoryAggregate;

public class Category : AggregateRoot
{
    private const int MaxNameLength = 50;

    private string _name = null!;
    private readonly List<Attribute> _attributes;


    public Category(IEnumerable<string> attributes)
    {
        _attributes = attributes.Select(a => new Attribute { Name = a }).ToList();
    }

    public IReadOnlyCollection<Attribute> Attributes => _attributes.AsReadOnly();

    public required string Name
    {
        get => _name;
        set => _name = value.ValidateLength(MaxNameLength);
    }

    public void UpdateAttributes(Product product)
    {
        if (product.CategoryId != Id)
            throw new ArgumentException("The product does not belong to this category", nameof(product));
        foreach (var attribute in _attributes)
        {
            // Получаем значение атрибута у продукта
            var productAttribute = product.Attributes[attribute.Name];

            attribute.AddOrUpdateValue(productAttribute);
        }
    }

    public void RemoveAttributes(Product product)
    {
        if (product.CategoryId != Id)
            throw new ArgumentException("The product does not belong to this category", nameof(product));
        foreach (var attribute in _attributes)
        {
            // Получаем значение атрибута у продукта
            var productAttribute = product.Attributes[attribute.Name];

            attribute.RemoveOrUpdateValue(productAttribute);
        }
    }
}