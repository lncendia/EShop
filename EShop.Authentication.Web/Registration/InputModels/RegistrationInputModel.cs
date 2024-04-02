using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Registration.InputModels;

/// <summary>
/// Модель регистрации аккаунта
/// </summary>
public class RegistrationInputModel
{
    /// <summary>
    /// Логин (имя) пользователя
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    [EmailAddress(ErrorMessage = "Укажите корректный адрес")]
    public string? Email { get; set; }

    /// <summary>
    /// Пароль
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public string? Password { get; set; }

    /// <summary>
    /// Получает или задает имя пользователя.
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public required string Username { get; init; }
    //todo: validation

    /// <summary>
    /// Url адрес для возврата после прохождения регистрации
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    [Url(ErrorMessage = "Укажите корректный URL")]
    public required string ConfirmUrl { get; init; }
}