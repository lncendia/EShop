using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.Abstractions.Interfaces;

public interface IRepository<T, out TX, out TM> where T : class
    where TX : ISpecificationVisitor<TX, T>
    where TM : ISortingVisitor<TM, T>
{
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(Guid id);
    Task<T?> GetAsync(Guid id);

    Task<IReadOnlyCollection<T>> FindAsync(ISpecification<T, TX>? specification, IOrderBy<T, TM>? orderBy = null, int? skip = null,
        int? take = null);

    Task<int> CountAsync(ISpecification<T, TX>? specification);
}