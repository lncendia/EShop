using MediatR;

namespace EShop.Authentication.Abstractions.Commands.Password;

/// <summary>
/// Команда для изменения пароля пользователя.
/// </summary>
public class ChangePasswordCommand : IRequest
{
    /// <summary>
    /// Получает идентификатор пользователя.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Получает старый пароль пользователя.
    /// </summary>
    public required string OldPassword { get; init; }

    /// <summary>
    /// Получает новый пароль пользователя.
    /// </summary>
    public required string NewPassword { get; init; }
}