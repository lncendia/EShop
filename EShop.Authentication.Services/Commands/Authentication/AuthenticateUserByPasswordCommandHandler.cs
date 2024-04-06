using EShop.Authentication.Abstractions.Commands.Authentication;
using EShop.Authentication.Abstractions.DTOs;
using EShop.Authentication.Abstractions.Exceptions;
using EShop.Authentication.Abstractions.Models;
using EShop.Authentication.Abstractions.TokenProvider;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace EShop.Authentication.Services.Commands.Authentication;

/// <summary>
/// Класс обработчика команды аутентификации пользователя по паролю.
/// </summary>
/// <param name="userManager">Менеджер пользователей, предоставленный ASP.NET Core Identity.</param>
public class AuthenticateUserByPasswordCommandHandler(
    UserManager<User> userManager,
    IUserClaimsPrincipalFactory<User> factory,
    ITokenProvider provider) : IRequestHandler<AuthenticateUserByPasswordCommand, Tokens>
{
    /// <summary>
    /// Обработка команды аутентификации пользователя по паролю.
    /// </summary>
    /// <param name="request">Запрос на аутентификацию пользователя.</param>
    /// <param name="cancellationToken">Токен отмены для асинхронной операции.</param>
    /// <returns>Объект пользователя в случае успешной аутентификации.</returns>
    /// <exception cref="UserNotFoundException">Вызывается, если пользователь не найден.</exception>
    /// <exception cref="UserLockoutException">Вызывается, если пользователь заблокирован.</exception>
    /// <exception cref="InvalidPasswordException">Вызывается, если валидация пароля не прошла.</exception>
    public async Task<Tokens> Handle(AuthenticateUserByPasswordCommand request, CancellationToken cancellationToken)
    {
        // Получаем пользователя по его электронной почте.
        var user = await userManager.FindByEmailAsync(request.Email);

        // Если пользователь не найден, вызываем исключение UserNotFoundException.
        if (user == null) throw new UserNotFoundException();

        // Проверяем заблокирован ли пользователь 
        if (await userManager.IsLockedOutAsync(user))
        {
            // Если пользователь заблокирован, вызываем исключение UserLockoutException.
            throw new UserLockoutException();
        }

        // Проверяем правильность введенного пароля.
        var success = await userManager.CheckPasswordAsync(user, request.Password);

        // Если пароль верный
        if (success)
        {
            // Cбрасываем счетчик неудачных попыток входа
            await userManager.ResetAccessFailedCountAsync(user);

            // Обновляем данные
            await userManager.UpdateAsync(user);

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

        // Если пароль неверный
        // Инкрементируем счетчик неудачных попыток
        await userManager.AccessFailedAsync(user);

        // Вызываем исключение InvalidPasswordException.
        throw new InvalidPasswordException();
    }
}