using System.Linq.Expressions;
using EShop.Application.Storage.Models.User;
using EShop.Domain.Specifications.Abstractions;
using EShop.Domain.UserAggregate;
using EShop.Domain.UserAggregate.Specifications.Visitor;

namespace EShop.Application.Storage.Visitors.Specifications;

public class UserVisitor : BaseVisitor<UserModel, IUserSpecificationVisitor, User>, IUserSpecificationVisitor
{
    protected override Expression<Func<UserModel, bool>> ConvertSpecToExpression(
        ISpecification<User, IUserSpecificationVisitor> spec)
    {
        var visitor = new UserVisitor();
        spec.Accept(visitor);
        return visitor.Expr!;
    }
}