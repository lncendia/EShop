using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Settings.InputModels;

/// <summary>
/// Модель смены пароля
/// </summary>
public class ChangePasswordInputModel
{
    /// <summary>
    /// Старый пароль
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public string? OldPassword { get; init; }

    /// <summary>
    /// Новый пароль
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public string? NewPassword { get; init; }
}