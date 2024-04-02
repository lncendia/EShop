using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.OrderAggregate.Specifications.Visitor;

public interface IOrderSpecificationVisitor : ISpecificationVisitor<IOrderSpecificationVisitor, Order>;