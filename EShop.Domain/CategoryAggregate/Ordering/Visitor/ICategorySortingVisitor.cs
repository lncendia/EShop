using EShop.Domain.Ordering.Abstractions;

namespace EShop.Domain.CategoryAggregate.Ordering.Visitor;

public interface ICategorySortingVisitor : ISortingVisitor<ICategorySortingVisitor, Category>;