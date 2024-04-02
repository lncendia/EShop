namespace EShop.Application.Web.Products.ViewModels;

public class ProductShortViewModel
{
    public required Guid Id { get; init; }
    public required string PhotoUrl { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required CountType CountType { get; init; }
}

public enum CountType
{
    Available,
    Close,
    OutOfStock
}