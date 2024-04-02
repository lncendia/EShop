using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Account.InputModels;

/// <summary>
/// Модель запроса восстановления пароля
/// </summary>
public class ResetPasswordInputModel
{
    /// <summary>
    /// Модель ввода для сброса пароля.
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? Email { get; init; }

    /// <summary>
    /// Адрес возврата для письма
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    [Url(ErrorMessage = "Укажите корректный URL")]
    public string? ResetUrl { get; init; }
}