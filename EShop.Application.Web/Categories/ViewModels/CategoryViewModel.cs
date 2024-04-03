namespace EShop.Application.Web.Categories.ViewModels;

public class CategoryViewModel : CategoryShortViewModel
{
    public required IEnumerable<AttributeViewModel> Attributes { get; init; }
}