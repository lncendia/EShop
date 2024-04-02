using EShop.Authentication.Abstractions.Commands.Authentication;
using EShop.Authentication.Abstractions.Exceptions;
using EShop.Authentication.Abstractions.JwtGenerator;
using EShop.Authentication.Abstractions.Models;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Authentication.Services.Commands.Authentication;

/// <summary>
/// Класс обработчика  команды обновления токена.
/// </summary>
/// <param name="userManager">Менеджер пользователей, предоставленный ASP.NET Core Identity.</param>
public class RefreshTokenCommandHandler(
    UserManager<User> userManager,
    IUserClaimsPrincipalFactory<User> factory,
    IJwtGenerator generator) : IRequestHandler<RefreshTokenCommand, string>
{
    /// <summary>
    /// Обработка команды обновления токена.
    /// </summary>
    /// <param name="request">Запрос на обновление токена.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Объект пользователя в случае успешной аутентификации.</returns>
    /// <exception cref="UserNotFoundException">Вызывается, если пользователь не найден.</exception>
    public async Task<string> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        // Получаем пользователя по его электронной почте.
        var user = await userManager.FindByIdAsync(request.UserId.ToString());

        // Если пользователь не найден, вызываем исключение UserNotFoundException.
        if (user == null) throw new UserNotFoundException();
        
        var principal = await factory.CreateAsync(user);

        return await generator.GenerateAsync(principal.Claims);
    }
}