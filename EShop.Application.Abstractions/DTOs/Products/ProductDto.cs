namespace EShop.Application.Abstractions.DTOs.Products;

public class ProductDto : ProductShortDto
{
    public required IReadOnlyDictionary<string, string> Attributes { get; init; }
    public required Guid CategoryId { get; init; }
}