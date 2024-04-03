namespace EShop.Application.Abstractions.DTOs.Categories;

public class CategoryShortDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
}