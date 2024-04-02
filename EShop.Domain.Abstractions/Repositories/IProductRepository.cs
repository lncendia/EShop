using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Ordering.Visitor;
using EShop.Domain.ProductAggregate.Specifications.Visitor;

namespace EShop.Domain.Abstractions.Repositories;

public interface IProductRepository : IRepository<Product, IProductSpecificationVisitor, IProductSortingVisitor>;