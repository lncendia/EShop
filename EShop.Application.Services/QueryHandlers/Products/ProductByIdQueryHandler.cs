using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Services.Extensions;
using EShop.Application.Services.Mappers;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.UserAggregate;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Products;

public class ProductByIdQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<ProductByIdQuery, ProductDto>
{
    public async Task<ProductDto> Handle(ProductByIdQuery request, CancellationToken cancellationToken)
    {
        var product = await unitOfWork.ProductRepository.Value.GetAsync(request.Id);
        if (product == null) throw new ProductNotFoundException();

        User? user = null;
        if (request.UserId.HasValue) user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId.Value);

        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        return ProductMapper.Map(product, categories.First(c => c.Id == product.CategoryId), user);
    }
}