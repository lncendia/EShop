using MediatR;

namespace EShop.Application.Abstractions.Commands.Profile;

public class RemoveFromFavoriteCommand : IRequest
{
    public required Guid UserId { get; init; }
    public required Guid ProductId { get; init; }
}