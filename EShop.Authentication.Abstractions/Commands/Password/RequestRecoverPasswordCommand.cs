using MediatR;

namespace EShop.Authentication.Abstractions.Commands.Password;

/// <summary>
/// Команда для запроса восстановления пароля.
/// </summary>
public class RequestRecoverPasswordCommand : IRequest
{
    /// <summary>
    /// Получает или задает электронную почту пользователя.
    /// </summary>
    public required string Email { get; init; }

    /// <summary>
    /// Получает или задает URL для сброса пароля.
    /// </summary>
    public required string ResetUrl { get; init; }
}