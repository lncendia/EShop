namespace EShop.Application.Abstractions.DTOs.Categories;

public class CategoryDto : CategoryShortDto
{
    public required IReadOnlyCollection<AttributeDto> Attributes { get; init; }
}