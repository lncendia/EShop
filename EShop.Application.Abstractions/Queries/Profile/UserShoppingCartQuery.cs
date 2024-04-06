using EShop.Application.Abstractions.DTOs.Profile;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Profile;

public class UserShoppingCartQuery : IRequest<UserProductCountDto[]>
{
    public required Guid UserId { get; init; }
}