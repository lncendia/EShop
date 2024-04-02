using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.Specifications;

public class AndSpecification<T, TVisitor>(ISpecification<T, TVisitor> left, ISpecification<T, TVisitor> right)
    : ISpecification<T, TVisitor>
    where TVisitor : ISpecificationVisitor<TVisitor, T>
{
    public ISpecification<T, TVisitor> Left { get; } = left;
    public ISpecification<T, TVisitor> Right { get; } = right;

    public void Accept(TVisitor visitor) => visitor.Visit(this);
    public bool IsSatisfiedBy(T obj) => Left.IsSatisfiedBy(obj) && Right.IsSatisfiedBy(obj);
}