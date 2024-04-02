using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductsInStockSpecification : ISpecification<Product, IProductSpecificationVisitor>
{
    public bool IsSatisfiedBy(Product item) => item.Count > 0;

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}