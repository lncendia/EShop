using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Registration.InputModels;

public class ConfirmEmailInputModel
{
    /// <summary>
    /// Логин (имя) пользователя
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public Guid UserId { get; init; }

    /// <summary>
    /// Код подтверждения
    /// </summary>
    [Required(ErrorMessage = "Поле необходимо для заполнения")]
    public string? Code { get; init; }
}