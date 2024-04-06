namespace EShop.Application.Abstractions.DTOs.Profile;

public class UserProductDto
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string CategoryName { get; init; }
    public required string Description { get; init; }
    public required Uri PhotoUrl { get; init; }
    public required decimal Price { get; init; }
    public required int AvailableCount { get; init; }
}