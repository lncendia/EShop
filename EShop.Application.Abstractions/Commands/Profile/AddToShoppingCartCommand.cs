using MediatR;

namespace EShop.Application.Abstractions.Commands.Profile;

public class AddToShoppingCartCommand : IRequest
{
    public required Guid UserId { get; init; }
    public required Guid ProductId { get; init; }
    public required int Count { get; init; }
}