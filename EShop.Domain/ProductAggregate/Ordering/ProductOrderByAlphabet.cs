using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.ProductAggregate.Ordering.Visitor;

namespace EShop.Domain.ProductAggregate.Ordering;

public class ProductOrderByAlphabet : IOrderBy<Product, IProductSortingVisitor>
{
    public IEnumerable<Product> Order(IEnumerable<Product> items) => items.OrderBy(x => x.Name);

    public IReadOnlyCollection<IEnumerable<Product>> Divide(IEnumerable<Product> items) =>
        Order(items).GroupBy(x => x.Name).Select(x => x.AsEnumerable()).ToArray();

    public void Accept(IProductSortingVisitor visitor) => visitor.Visit(this);
}