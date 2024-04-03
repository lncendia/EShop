using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Settings.InputModels;

/// <summary>
/// Модель запроса смены почты
/// </summary>
public class RequestChangeEmailInputModel
{
    /// <summary>
    /// Почта пользователя
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? NewEmail { get; init; }
    
    /// <summary>
    /// Url адрес для возврата после прохождения регистрации
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [Url(ErrorMessage = "Укажите корректный URL")]
    public required string ResetUrl { get; init; }
}