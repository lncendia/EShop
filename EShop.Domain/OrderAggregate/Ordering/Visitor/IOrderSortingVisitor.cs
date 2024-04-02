using EShop.Domain.Ordering.Abstractions;

namespace EShop.Domain.OrderAggregate.Ordering.Visitor;

public interface IOrderSortingVisitor : ISortingVisitor<IOrderSortingVisitor, Order>;