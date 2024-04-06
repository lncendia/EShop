using EShop.Authentication.Abstractions.DTOs;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Authentication.Abstractions.Commands.Authentication;

/// <summary>
/// Команда для аутентификации пользователя по паролю.
/// </summary>
public class AuthenticateUserByPasswordCommand : IRequest<Tokens>
{
    /// <summary>
    /// Получает или задает электронную почту пользователя.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// Получает или задает пароль пользователя.
    /// </summary>
    public required string Password { get; init; }
}