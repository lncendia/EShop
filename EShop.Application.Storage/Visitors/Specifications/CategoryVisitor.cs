using System.Linq.Expressions;
using EShop.Application.Storage.Models.Category;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.CategoryAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Application.Storage.Visitors.Specifications;

public class CategoryVisitor : BaseVisitor<CategoryModel, ICategorySpecificationVisitor, Category>,
    ICategorySpecificationVisitor
{
    protected override Expression<Func<CategoryModel, bool>> ConvertSpecToExpression(
        ISpecification<Category, ICategorySpecificationVisitor> spec)
    {
        var visitor = new CategoryVisitor();
        spec.Accept(visitor);
        return visitor.Expr!;
    }
}