using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByAttributeSpecification(string name, string value)
    : ISpecification<Product, IProductSpecificationVisitor>
{
    public string Name { get; } = name;
    public string Value { get; } = value;

    public bool IsSatisfiedBy(Product item) => item.Attributes[Name] == Value;

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}