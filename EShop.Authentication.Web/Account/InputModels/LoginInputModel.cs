using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Account.InputModels;

/// <summary>
/// Модель входа в систему
/// </summary>
public class LoginInputModel
{
    /// <summary>
    /// Логин (имя) пользователя
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? Email { get; init; }

    /// <summary>
    /// Пароль
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string? Password { get; init; }
}