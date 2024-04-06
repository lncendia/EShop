using EShop.Authentication.Abstractions.Commands.Authentication;
using EShop.Authentication.Abstractions.DTOs;
using EShop.Authentication.Abstractions.Exceptions;
using EShop.Authentication.Abstractions.Models;
using EShop.Authentication.Abstractions.TokenProvider;
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
    ITokenProvider provider) : IRequestHandler<RefreshTokenCommand, Tokens>
{
    /// <summary>
    /// Обработка команды обновления токена.
    /// </summary>
    /// <param name="request">Запрос на обновление токена.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Объект пользователя в случае успешной аутентификации.</returns>
    /// <exception cref="UserNotFoundException">Вызывается, если пользователь не найден.</exception>
    public async Task<Tokens> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
    {
        var token = provider.DecryptRefresh(request.Token);

        if (token.Expiration < DateTime.Now) throw new RefreshTokenExpiredException();
        
        // Получаем пользователя по его электронной почте.
        var user = await userManager.FindByIdAsync(token.Id.ToString());

        // Если пользователь не найден, вызываем исключение UserNotFoundException.
        if (user == null) throw new UserNotFoundException();
        
        var principal = await factory.CreateAsync(user);

        var accessToken = provider.GenerateAccess(principal.Claims);
        var refresh = provider.GenerateRefresh(user.Id);

        return new Tokens
        {
            AccessToken = accessToken,
            RefreshToken = refresh.token,
            RefreshTokenExpiration = refresh.expiration
        };
    }
}