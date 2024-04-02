using EShop.Application.Storage.Models.User;
using EShop.Application.Storage.Visitors.Sorting.Models;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.UserAggregate;
using EShop.Domain.UserAggregate.Ordering.Visitor;

namespace EShop.Application.Storage.Visitors.Sorting;

public class UserSortingVisitor : BaseSortingVisitor<UserModel, IUserSortingVisitor, User>, IUserSortingVisitor
{
    protected override List<SortData<UserModel>> ConvertOrderToList(IOrderBy<User, IUserSortingVisitor> spec)
    {
        var visitor = new UserSortingVisitor();
        spec.Accept(visitor);
        return visitor.SortItems;
    }
}