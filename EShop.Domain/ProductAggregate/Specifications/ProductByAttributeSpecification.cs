using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByAttributeSpecification(string name, IEnumerable<string> values)
    : ISpecification<Product, IProductSpecificationVisitor>
{
    public string Name { get; } = name;
    public IEnumerable<string> Values { get; } = values;

    public bool IsSatisfiedBy(Product item) => Values.Any(a=> a == item.Attributes[Name]);

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}