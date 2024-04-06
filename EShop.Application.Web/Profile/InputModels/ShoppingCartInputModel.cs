using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Web.Profile.InputModels;

public class ShoppingCartInputModel : ProductInputModel
{
    [Required(ErrorMessage = "Поле обязательно для заполнения")]
    [Range(1, 255, ErrorMessage = "Должно быть больше 0 и меньше 256")]
    public int Count { get; init; }
}