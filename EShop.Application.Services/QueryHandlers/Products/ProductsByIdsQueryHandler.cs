using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Services.Extensions;
using EShop.Application.Services.Mappers;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.ProductAggregate.Specifications;
using EShop.Domain.UserAggregate;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Products;

public class ProductsByIdsQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<ProductsByIdsQuery, ProductDto[]>
{
    public async Task<ProductDto[]> Handle(ProductsByIdsQuery request, CancellationToken cancellationToken)
    {
        var specification = new ProductByIdsSpecification(request.Ids);

        var products = await unitOfWork.ProductRepository.Value.FindAsync(specification);

        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        User? user = null;
        if (request.UserId.HasValue) user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId.Value);

        return products
            .Select(p => ProductMapper.Map(p, categories.First(c => c.Id == p.CategoryId), user))
            .ToArray();
    }
}