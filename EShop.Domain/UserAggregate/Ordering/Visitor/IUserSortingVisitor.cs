using EShop.Domain.Ordering.Abstractions;

namespace EShop.Domain.UserAggregate.Ordering.Visitor;

public interface IUserSortingVisitor : ISortingVisitor<IUserSortingVisitor, User>;