using System.Linq.Expressions;

namespace EShop.Application.Storage.Visitors.Sorting.Models;

public class SortData<TEntity>(Expression<Func<TEntity, dynamic>> expr, bool isDescending)
{
    public Expression<Func<TEntity, dynamic>> Expr { get; } = expr;
    public bool IsDescending { get; } = isDescending;
}