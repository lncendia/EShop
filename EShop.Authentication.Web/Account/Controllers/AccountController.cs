using EShop.Authentication.Abstractions.Commands.Authentication;
using EShop.Authentication.Abstractions.Commands.Password;
using EShop.Authentication.Abstractions.DTOs;
using EShop.Authentication.Web.Account.InputModels;
using EShop.Authentication.Web.Common.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Authentication.Web.Account.Controllers;

/// <summary>
/// Контроллер для прохождения аутентификации.
/// </summary>
[Route("auth/[controller]/[action]")]
[ApiController]
public class AccountController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Обработка аутентификации
    /// </summary>
    /// <param name="model">Модель входа в систему</param>
    [HttpPost]
    public async Task<TokensViewModel> Token(LoginInputModel model)
    {
        // Попытка аутентификации пользователя с использованием введенных учетных данных.
        var tokens = await mediator.Send(new AuthenticateUserByPasswordCommand
        {
            Email = model.Email!,
            Password = model.Password!
        });

        return Map(tokens);
    }

    /// <summary>
    /// Обновление токена
    /// </summary>
    [HttpGet]
    public async Task<TokensViewModel> RefreshToken(string refreshToken)
    {
        // Попытка аутентификации пользователя с использованием введенных учетных данных.
        var tokens = await mediator.Send(new RefreshTokenCommand { Token = refreshToken});

        return Map(tokens);
    }

    /// <summary>
    /// Запрос на сброс пароля.
    /// </summary>
    /// <param name="model">Модель ввода для сброса пароля.</param>
    [HttpPost]
    public async Task RecoverPassword(RecoverPasswordInputModel model)
    {
        // Отправляем команду на смену пароля
        await mediator.Send(new RequestRecoverPasswordCommand
        {
            // Почта
            Email = model.Email!,

            // Url смены пароля
            ResetUrl = model.ResetUrl!
        });
    }

    /// <summary>
    /// Установка нового пароля.
    /// </summary>
    /// <param name="model">Модель ввода для нового пароля.</param>
    /// <returns>Результат действия после сброса пароля.</returns>
    [HttpPost]
    public async Task<IActionResult> NewPassword(NewPasswordInputModel model)
    {
        // Отправляем команду на сброс пароля и установку нового пароля
        await mediator.Send(new RecoverPasswordCommand
        {
            // Код сброса пароля
            Code = model.Code!,

            // Почта
            Email = model.Email!,

            // Новый пароль
            NewPassword = model.NewPassword!
        });

        // Перенаправляем пользователя на страницу входа и устанавливаем returnUrl
        return Ok();
    }

    private static TokensViewModel Map(Tokens tokens) => new()
    {
        AccessToken = tokens.AccessToken,
        RefreshToken = tokens.RefreshToken,
        RefreshTokenExpiration = tokens.RefreshTokenExpiration
    };
}