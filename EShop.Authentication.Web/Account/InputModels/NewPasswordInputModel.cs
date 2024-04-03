using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Account.InputModels;

/// <summary>
/// Модель установки нового пароля
/// </summary>
public class NewPasswordInputModel
{
    /// <summary>
    /// Модель ввода для нового пароля.
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string? NewPassword { get; init; }

    /// <summary>
    /// Адрес электронной почты.
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? Email { get; init; }

    /// <summary>
    /// Код.
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string? Code { get; init; }
}