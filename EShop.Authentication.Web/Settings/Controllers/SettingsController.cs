using EShop.Authentication.Abstractions.Commands.Email;
using EShop.Authentication.Abstractions.Commands.Password;
using EShop.Authentication.Abstractions.Commands.Profile;
using EShop.Authentication.Web.Settings.InputModels;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Authentication.Web.Settings.Controllers;

/// <summary>
/// Контроллер для изменения настроек аккаунта
/// </summary>
[Authorize]
[Route("auth/[controller]/[action]")]
[ApiController]
public class SettingsController(ISender mediator) : ControllerBase
{
    /// <summary>
    /// Метод, который изменяет пароль пользователя.
    /// </summary>
    /// <param name="model">Модель с данными для смены пароля</param>
    /// <returns>Результат смены пароля</returns>
    [HttpPost]
    public async Task ChangePassword(ChangePasswordInputModel model)
    {
        // Отправляем команду на смену пароля и получаем пользователя с обновленными данными
        await mediator.Send(new ChangePasswordCommand
        {
            UserId = User.Id(),
            OldPassword = model.OldPassword!,
            NewPassword = model.NewPassword!
        });
    }

    /// <summary>
    /// Метод для запроса изменения адреса электронной почты пользователя.
    /// </summary>
    /// <param name="model">Модель ввода, содержащая новый адрес электронной почты и другие соответствующие данные.</param>
    /// <returns>Объект IActionResult, представляющий результат операции.</returns>
    [HttpPost]
    public async Task RequestChangeEmail(RequestChangeEmailInputModel model)
    {
        await mediator.Send(new RequestChangeEmailCommand
        {
            // Идентификатор пользователя
            UserId = User.Id(),

            // Новая почта
            NewEmail = model.NewEmail!,

            // Url для сброса почты и установки новой
            ResetUrl = model.ResetUrl
        });
    }

    /// <summary>
    /// Метод для изменения адреса электронной почты пользователя.
    /// </summary>
    /// <param name="model">Модель смены почты.</param>
    [HttpPost]
    public async Task ChangeEmail(ConfirmChangeEmailInputModel model)
    {
        // Отправляем команду на смену почты и получаем пользователя с обновленными данными
        await mediator.Send(new ChangeEmailCommand
        {
            // Код смены почты
            Code = model.Code!,

            // Новая почта
            NewEmail = model.NewEmail!,

            // Идентификатор пользователя
            UserId = User.Id()
        });
    }

    /// <summary>
    /// Метод для изменения имени пользователя.
    /// </summary>
    /// <param name="model">Модель с данными смены имени.</param>
    [HttpPost]
    public async Task ChangeName(ChangeNameInputModel model)
    {
        await mediator.Send(new ChangeNameCommand
        {
            // Идентификатор пользователя
            UserId = User.Id(),

            // Имя пользователя
            Name = model.Username!
        });
    }
}