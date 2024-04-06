using EShop.Application.Web.Common.Enums;

namespace EShop.Application.Web.Products.ViewModels;

public class ProductViewModel
{
    public required Guid Id { get; init; }
    public required string PhotoUrl { get; init; }
    public required string Name { get; init; }
    public required string Description { get; init; }
    public required decimal Price { get; init; }
    public required CountType CountType { get; init; }
    public required Guid CategoryId { get; init; }
    public required string CategoryName { get; init; }
    public required bool InShoppingCart { get; init; }
    public required bool InFavorite { get; init; }
    public required IReadOnlyDictionary<string, string> Attributes { get; init; }
}