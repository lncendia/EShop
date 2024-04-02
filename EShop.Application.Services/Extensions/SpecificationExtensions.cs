using EShop.Domain.Specifications;
using EShop.Domain.Specifications.Abstractions;

namespace EShop.Application.Services.Extensions;

public static class SpecificationExtensions
{
    public static ISpecification<T, TV> AddToSpecification<T, TV>(this ISpecification<T, TV>? baseSpec,
        ISpecification<T, TV> newSpec) where TV : ISpecificationVisitor<TV, T>
    {
        return baseSpec == null ? newSpec : new AndSpecification<T, TV>(baseSpec, newSpec);
    }
}