using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.CategoryAggregate.Ordering.Visitor;
using EShop.Domain.CategoryAggregate.Specifications.Visitor;

namespace EShop.Domain.Abstractions.Repositories;

public interface ICategoryRepository : IRepository<Category, ICategorySpecificationVisitor, ICategorySortingVisitor>;