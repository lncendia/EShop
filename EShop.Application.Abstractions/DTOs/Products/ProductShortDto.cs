namespace EShop.Application.Abstractions.DTOs.Products;

public class ProductShortDto
{
    public required Guid Id { get; init; }
    public required Uri PhotoUrl { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required int Count { get; init; }
}