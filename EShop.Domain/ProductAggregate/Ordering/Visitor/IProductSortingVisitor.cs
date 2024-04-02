using EShop.Domain.Ordering.Abstractions;

namespace EShop.Domain.ProductAggregate.Ordering.Visitor;

public interface IProductSortingVisitor : ISortingVisitor<IProductSortingVisitor, Product>
{
    void Visit(ProductOrderByPrice order);
    void Visit(ProductOrderByAlphabet order);
}