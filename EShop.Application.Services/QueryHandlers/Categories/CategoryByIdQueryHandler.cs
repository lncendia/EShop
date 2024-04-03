using EShop.Application.Abstractions.DTOs.Categories;
using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Queries.Categories;
using EShop.Application.Services.Extensions;
using EShop.Domain.Abstractions.Interfaces;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Categories;

public class CategoryByIdQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<CategoryByIdQuery, CategoryDto>
{
    public async Task<CategoryDto> Handle(CategoryByIdQuery request, CancellationToken cancellationToken)
    {
        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        var category = categories.FirstOrDefault(c => c.Id == request.Id);
        if (category == null) throw new CategoryNotFoundException();

        return new CategoryDto
        {
            Id = category.Id,
            Name = category.Name,
            Attributes = category.Attributes.Select(a => new AttributeDto
            {
                Name = a.Name,
                Values = a.Values
            }).ToArray()
        };
    }
}