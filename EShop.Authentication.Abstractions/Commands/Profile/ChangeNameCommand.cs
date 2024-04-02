using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Authentication.Abstractions.Commands.Profile;

/// <summary>
/// Команда для изменения имени пользователя.
/// </summary>
public class ChangeNameCommand : IRequest
{
    /// <summary>
    /// Идентификатор пользователя.
    /// </summary>
    public required Guid UserId { get; init; }

    /// <summary>
    /// Новое имя пользователя.
    /// </summary>
    public required string Name { get; init; }
}