using System.Diagnostics.CodeAnalysis;
using System.Linq.Expressions;
using EShop.Application.Storage.Models.Product;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Specifications;
using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Application.Storage.Visitors.Specifications;

[SuppressMessage("Performance",
    "CA1862:Используйте перегрузки метода \"StringComparison\" для сравнения строк без учета регистра")]
public class ProductVisitor : BaseVisitor<ProductModel, IProductSpecificationVisitor, Product>,
    IProductSpecificationVisitor
{
    protected override Expression<Func<ProductModel, bool>> ConvertSpecToExpression(
        ISpecification<Product, IProductSpecificationVisitor> spec)
    {
        var visitor = new ProductVisitor();
        spec.Accept(visitor);
        return visitor.Expr!;
    }

    public void Visit(ProductByAttributeSpecification specification) => Expr = x =>
        x.Attributes.Any(a => a.Name == specification.Name && specification.Values.Any(v => v == a.Value));

    public void Visit(ProductByPriceSpecification specification) =>
        Expr = x => x.Price >= specification.Min && x.Price <= specification.Max;

    public void Visit(ProductByNameSpecification specification) =>
        Expr = x => x.Name.ToUpper().Contains(specification.Name.ToUpper());

    public void Visit(ProductsInStockSpecification specification) => Expr = x => x.Count > 0;

    public void Visit(ProductByCategorySpecification specification) =>
        Expr = x => x.CategoryId == specification.CategoryId;

    public void Visit(ProductByIdsSpecification specification) => Expr = x => specification.Ids.Contains(x.Id);
}