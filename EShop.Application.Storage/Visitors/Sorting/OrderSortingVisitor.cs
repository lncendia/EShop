using EShop.Application.Storage.Models.Order;
using EShop.Application.Storage.Visitors.Sorting.Models;
using EShop.Domain.OrderAggregate;
using EShop.Domain.OrderAggregate.Ordering.Visitor;
using EShop.Domain.Ordering.Abstractions;

namespace EShop.Application.Storage.Visitors.Sorting;

public class OrderSortingVisitor : BaseSortingVisitor<OrderModel, IOrderSortingVisitor, Order>,
    IOrderSortingVisitor
{
    protected override List<SortData<OrderModel>> ConvertOrderToList(IOrderBy<Order, IOrderSortingVisitor> spec)
    {
        var visitor = new OrderSortingVisitor();
        spec.Accept(visitor);
        return visitor.SortItems;
    }
}