using EShop.Application.Abstractions.DTOs.Common;
using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Services.Extensions;
using EShop.Application.Services.Mappers;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.Ordering;
using EShop.Domain.Ordering.Abstractions;
using EShop.Domain.ProductAggregate;
using EShop.Domain.ProductAggregate.Ordering;
using EShop.Domain.ProductAggregate.Ordering.Visitor;
using EShop.Domain.ProductAggregate.Specifications;
using EShop.Domain.ProductAggregate.Specifications.Visitor;
using EShop.Domain.Specifications.Abstractions;
using EShop.Domain.UserAggregate;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Products;

public class SearchProductsQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<SearchProductsQuery, ListDto<ProductDto>>
{
    public async Task<ListDto<ProductDto>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
    {
        ISpecification<Product, IProductSpecificationVisitor>? specification = null;

        if (request.CategoryId.HasValue)
            specification =
                specification.AddToSpecification(new ProductByCategorySpecification(request.CategoryId.Value));

        if (request.Query != null)
            specification = specification.AddToSpecification(new ProductByNameSpecification(request.Query));

        if (request.MinPrice.HasValue || request.MaxPrice.HasValue)
            specification =
                specification.AddToSpecification(new ProductByPriceSpecification(request.MinPrice, request.MaxPrice));

        if (request.Attributes != null)
        {
            foreach (var attribute in request.Attributes)
            {
                specification = specification.AddToSpecification(
                    new ProductByAttributeSpecification(attribute.Name, attribute.Values));
            }
        }

        IOrderBy<Product, IProductSortingVisitor> order = request.Order switch
        {
            ProductOrder.Alphabet => new ProductOrderByAlphabet(),
            ProductOrder.AlphabetDesc => new DescendingOrder<Product, IProductSortingVisitor>(
                new ProductOrderByAlphabet()),
            ProductOrder.Price => new ProductOrderByPrice(),
            ProductOrder.PriceDesc => new DescendingOrder<Product, IProductSortingVisitor>(new ProductOrderByPrice()),
            _ => throw new ArgumentOutOfRangeException()
        };

        var products =
            await unitOfWork.ProductRepository.Value.FindAsync(specification, order, request.Skip, request.Take);

        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);
        
        User? user = null;
        if (request.UserId.HasValue) user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId.Value);
        
        return new ListDto<ProductDto>
        {
            List = products.Select(p => ProductMapper.Map(p, categories.First(c => c.Id == p.CategoryId), user)).ToArray(),
            TotalCount = await unitOfWork.ProductRepository.Value.CountAsync(specification)
        };
    }
}