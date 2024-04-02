using EShop.Application.Storage.Models.Product;
using EShop.Application.Storage.Visitors.Sorting.Models;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Ordering;
using EShop.Domain.ProductAggregate.Ordering.Visitor;

namespace EShop.Application.Storage.Visitors.Sorting;

public class ProductSortingVisitor : BaseSortingVisitor<ProductModel, IProductSortingVisitor, Product>,
    IProductSortingVisitor
{
    public void Visit(ProductOrderByPrice order) =>
        SortItems.Add(new SortData<ProductModel>(x => x.Price, false));

    public void Visit(ProductOrderByAlphabet order)=>
        SortItems.Add(new SortData<ProductModel>(x => x.Name, false));

    protected override List<SortData<ProductModel>> ConvertOrderToList(
        IOrderBy<Product, IProductSortingVisitor> spec)
    {
        var visitor = new ProductSortingVisitor();
        spec.Accept(visitor);
        return visitor.SortItems;
    }
}