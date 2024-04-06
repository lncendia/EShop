using EShop.Application.Abstractions.DTOs.Profile;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Profile;

public class UserFavoritesQuery : IRequest<UserProductDto[]>
{
    public required Guid UserId { get; init; }
}