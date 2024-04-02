using MediatR;

namespace EShop.Authentication.Abstractions.Commands.Authentication;

/// <summary>
/// Команда для обновления токена.
/// </summary>
public class RefreshTokenCommand : IRequest<string>
{
    /// <summary>
    /// Получает или задает идентификатор пользователя.
    /// </summary>
    public required Guid UserId { get; init; }
}