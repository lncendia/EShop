namespace EShop.Application.Abstractions.DTOs.Profile;

public class UserProductCountDto : UserProductDto
{
    public required int Count { get; init; }
}