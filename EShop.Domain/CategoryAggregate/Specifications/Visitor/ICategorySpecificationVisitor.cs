using EShop.Domain.Specifications.Abstractions;

namespace EShop.Domain.CategoryAggregate.Specifications.Visitor;

public interface ICategorySpecificationVisitor : ISpecificationVisitor<ICategorySpecificationVisitor, Category>;