using EShop.Domain.CategoryAggregate.ValueObjects;

namespace EShop.Application.Abstractions.DTOs.Categories;

public class AttributeDto
{
    public required string Name { get; init; }
    public required IReadOnlyCollection<AttributeValue> Values { get; init; }
}