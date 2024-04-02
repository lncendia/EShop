namespace EShop.Application.Abstractions.DTOs.Categories;

public class CategoryDto
{
    public required string Name { get; init; }
    public required IReadOnlyCollection<AttributeDto> Attributes { get; init; }
}