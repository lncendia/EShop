using EShop.Authentication.Abstractions.Commands.Create;
using EShop.Authentication.Abstractions.Commands.Email;
using EShop.Authentication.Web.Common.ViewModels;
using EShop.Authentication.Web.Registration.InputModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Authentication.Web.Registration.Controllers;

/// <summary>
/// Контроллер для прохождения регистрации.
/// </summary>
[Route("auth/[controller]/[action]")]
[ApiController]
public class RegistrationController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Обработка регистрации пользователя
    /// </summary>
    /// <param name="model">Модель входа в систему</param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    [HttpPost]
    public async Task<TokensViewModel> Registration(RegistrationInputModel model)
    {
        // Отправляем команду на создание пользователя
        var tokens = await mediator.Send(new CreateUserCommand
        {
            // Почта
            Email = model.Email!,

            // Пароль
            Password = model.Password!,

            // Url подтверждения почты
            ConfirmUrl = model.ConfirmUrl,

            // Имя пользователя
            Username = model.Username
        });
        
        return new TokensViewModel
        {
            AccessToken = tokens.AccessToken,
            RefreshToken = tokens.RefreshToken,
            RefreshTokenExpiration = tokens.RefreshTokenExpiration
        };
    }

    /// <summary>
    /// Метод подтверждения email
    /// </summary>
    /// <param name="model">Модель подтверждения email</param>
    [HttpPost]
    public async Task ConfirmEmail(ConfirmEmailInputModel model)
    {
        // Верифицируем email
        await mediator.Send(new VerifyEmailCommand
        {
            // Идентификатор пользователя
            UserId = model.UserId,

            // Код подтверждения
            Code = model.Code!
        });
    }
}