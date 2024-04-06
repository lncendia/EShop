using MediatR;

namespace EShop.Application.Abstractions.Commands.CreateOrderCommand;

public class CreateOrderCommand : IRequest<Guid>
{
    public required Guid UserId { get; init; }
}