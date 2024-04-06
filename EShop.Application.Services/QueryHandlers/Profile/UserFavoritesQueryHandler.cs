using EShop.Application.Abstractions.DTOs.Profile;
using EShop.Application.Abstractions.Exceptions;
using EShop.Application.Abstractions.Queries.Profile;
using EShop.Application.Services.Extensions;
using EShop.Application.Services.Mappers;
using EShop.Domain.Abstractions.Interfaces;
using EShop.Domain.ProductAggregate.Specifications;
using MediatR;
using Microsoft.Extensions.Caching.Memory;

namespace EShop.Application.Services.QueryHandlers.Profile;

public class UserFavoritesQueryHandler(IUnitOfWork unitOfWork, IMemoryCache cache)
    : IRequestHandler<UserFavoritesQuery, UserProductDto[]>
{
    public async Task<UserProductDto[]> Handle(UserFavoritesQuery request, CancellationToken cancellationToken)
    {
        var user = await unitOfWork.UserRepository.Value.GetAsync(request.UserId);
        if (user == null) throw new UserNotFoundException();

        if (user.Favorites.Count == 0) return [];

        var specification = new ProductByIdsSpecification(user.Favorites);

        var products = await unitOfWork.ProductRepository.Value.FindAsync(specification);

        var categories = await cache.TryGetCategoriesFromCacheAsync(unitOfWork);

        return products
            .Select(p => ProfileMapper.Map(p, categories.First(c => c.Id == p.CategoryId)))
            .ToArray();
    }
}