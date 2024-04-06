using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Web.Profile.InputModels;

public class ProductInputModel
{
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    public Guid Id { get; init; }
}