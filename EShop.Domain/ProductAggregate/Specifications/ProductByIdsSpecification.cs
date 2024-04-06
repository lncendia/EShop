using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByIdsSpecification(IEnumerable<Guid> ids) : ISpecification<Product, IProductSpecificationVisitor>
{
    public IEnumerable<Guid> Ids { get; } = ids;
    public bool IsSatisfiedBy(Product item) => Ids.Any(i => item.Id == i);

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}