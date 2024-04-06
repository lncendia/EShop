using MediatR;

namespace EShop.IntegrationEvents;

public class UserCreatedIntegrationEvent : INotification
{
    public required Guid Id { get; init; }
    public required string Username { get; init; }
    public required string Email { get; init; }
}