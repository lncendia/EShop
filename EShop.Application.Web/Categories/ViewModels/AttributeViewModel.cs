namespace EShop.Application.Web.Categories.ViewModels;

public class AttributeViewModel
{
    public required string Name { get; init; }
    public required IEnumerable<AttributeValueViewModel> Values { get; init; }
}