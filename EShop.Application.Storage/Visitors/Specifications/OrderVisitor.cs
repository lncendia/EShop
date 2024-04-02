using System.Linq.Expressions;
using EShop.Application.Storage.Models.Order;
using EShop.Domain.OrderAggregate;
using EShop.Domain.OrderAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Application.Storage.Visitors.Specifications;

public class OrderVisitor : BaseVisitor<OrderModel, IOrderSpecificationVisitor, Order>, IOrderSpecificationVisitor
{
    protected override Expression<Func<OrderModel, bool>> ConvertSpecToExpression(
        ISpecification<Order, IOrderSpecificationVisitor> spec)
    {
        var visitor = new OrderVisitor();
        spec.Accept(visitor);
        return visitor.Expr!;
    }
}