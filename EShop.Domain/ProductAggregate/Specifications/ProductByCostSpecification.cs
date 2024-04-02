using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByPriceSpecification(decimal? min, decimal? max) : ISpecification<Product, IProductSpecificationVisitor>
{
    public decimal Min { get; } = min ?? decimal.MinValue;
    public decimal Max { get; } = max ?? decimal.MaxValue;
    public bool IsSatisfiedBy(Product item) => item.Price >= Min && item.Price <= Max;

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}