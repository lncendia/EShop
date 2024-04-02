using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications;

public class ProductByCategorySpecification(Guid categoryId) : ISpecification<Product, IProductSpecificationVisitor>
{
    public Guid CategoryId { get; } = categoryId;
    public bool IsSatisfiedBy(Product item) => item.CategoryId == CategoryId;

    public void Accept(IProductSpecificationVisitor visitor) => visitor.Visit(this);
}