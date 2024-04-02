using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Settings.InputModels;

/// <summary>
/// Модель запроса смены почты
/// </summary>
public class ConfirmChangeEmailInputModel
{
    /// <summary>
    /// Новая почта пользователя
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? NewEmail { get; init; }
    
    /// <summary>
    /// Код подтверждения
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public string? Code { get; init; }
}