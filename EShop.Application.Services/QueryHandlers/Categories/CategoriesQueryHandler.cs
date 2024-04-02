using EShop.Application.Abstractions.DTOs.Categories;
using EShop.Application.Abstractions.Queries.Categories;
using EShop.Application.Services.Extensions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Categories;

public class CategoriesQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<CategoriesQuery, IReadOnlyCollection<CategoryDto>>
{
    public async Task<IReadOnlyCollection<CategoryDto>> Handle(CategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        return categories.Select(c => new CategoryDto
        {
            Name = c.Name,
            Attributes = c.Attributes.Select(a => new AttributeDto { Name = a.Name, Values = a.Values }).ToArray()
        }).ToArray();
    }
}