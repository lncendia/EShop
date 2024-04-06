using EShop.Authentication.Abstractions.DTOs;
using MediatR;

namespace EShop.Authentication.Abstractions.Commands.Authentication;

/// <summary>
/// Команда для обновления токена.
/// </summary>
public class RefreshTokenCommand : IRequest<Tokens>
{
    /// <summary>
    /// Получает или задает токен обновления.
    /// </summary>
    public required string Token { get; init; }
}