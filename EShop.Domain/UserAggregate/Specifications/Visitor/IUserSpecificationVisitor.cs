using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.UserAggregate.Specifications.Visitor;

public interface IUserSpecificationVisitor : ISpecificationVisitor<IUserSpecificationVisitor, User>;