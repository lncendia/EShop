using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.UserAggregate;
using EShop.Domain.UserAggregate.Ordering.Visitor;
using EShop.Domain.UserAggregate.Specifications.Visitor;

namespace EShop.Domain.Abstractions.Repositories;

public interface IUserRepository : IRepository<User, IUserSpecificationVisitor, IUserSortingVisitor>;