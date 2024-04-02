using EShop.Application.Storage.Models.Category;
using EShop.Application.Storage.Visitors.Sorting.Models;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.CategoryAggregate.Ordering.Visitor;
using EShop.Domain.Ordering.Abstractions;

namespace EShop.Application.Storage.Visitors.Sorting;

public class CategorySortingVisitor : BaseSortingVisitor<CategoryModel, ICategorySortingVisitor, Category>,
    ICategorySortingVisitor
{
    protected override List<SortData<CategoryModel>> ConvertOrderToList(
        IOrderBy<Category, ICategorySortingVisitor> spec)
    {
        var visitor = new CategorySortingVisitor();
        spec.Accept(visitor);
        return visitor.SortItems;
    }
}