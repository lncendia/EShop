using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.ProductAggregate.Specifications.Visitor;

public interface IProductSpecificationVisitor : ISpecificationVisitor<IProductSpecificationVisitor, Product>
{
    void Visit(ProductByAttributeSpecification specification);
    void Visit(ProductByPriceSpecification specification);
    void Visit(ProductByNameSpecification specification);
    void Visit(ProductsInStockSpecification specification);
    void Visit(ProductByCategorySpecification specification);
}