using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.OrderAggregate;
using EShop.Domain.OrderAggregate.Ordering.Visitor;
using EShop.Domain.OrderAggregate.Specifications.Visitor;

namespace EShop.Domain.Abstractions.Repositories;

public interface IOrderRepository : IRepository<Order, IOrderSpecificationVisitor, IOrderSortingVisitor>;