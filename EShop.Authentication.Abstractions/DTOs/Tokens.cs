namespace EShop.Authentication.Abstractions.DTOs;

public class Tokens
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
    public required DateTime RefreshTokenExpiration { get; init; }
}