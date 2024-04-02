using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByNameSpecification(string name) : ISpecification<Product, IProductSpecificationVisitor>
{
    public string Name { get; } = name;
    public bool IsSatisfiedBy(Product item) => item.Name.Contains(Name, StringComparison.CurrentCultureIgnoreCase);

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}