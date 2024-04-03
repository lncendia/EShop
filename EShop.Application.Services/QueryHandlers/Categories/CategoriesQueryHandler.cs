using EShop.Application.Abstractions.DTOs.Categories;
using EShop.Application.Abstractions.Queries.Categories;
using EShop.Application.Services.Extensions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Categories;

public class CategoriesQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<CategoriesQuery, IReadOnlyCollection<CategoryShortDto>>
{
    public async Task<IReadOnlyCollection<CategoryShortDto>> Handle(CategoriesQuery request,
        CancellationToken cancellationToken)
    {
        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        return categories.Select(c => new CategoryShortDto { Id = c.Id, Name = c.Name }).ToArray();
    }
}