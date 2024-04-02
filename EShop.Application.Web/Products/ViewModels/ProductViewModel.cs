namespace EShop.Application.Web.Products.ViewModels;

public class ProductViewModel : ProductShortViewModel
{
    public required IReadOnlyDictionary<string, string> Attributes { get; init; }
    public required Guid CategoryId { get; init; }
}