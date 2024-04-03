using System.ComponentModel.DataAnnotations;

namespace EShop.Authentication.Web.Settings.InputModels;

/// <summary>
/// Модель ввода для изменения имени.
/// </summary>
public class ChangeNameInputModel
{
    /// <summary>
    /// Получает или задает имя пользователя.
    /// </summary>
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public string? Username { get; init; }
}