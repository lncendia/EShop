namespace EShop.Authentication.Abstractions.TokenProvider;

public class RefreshTokenData
{
    public required Guid Id { get; init; }
    public required DateTime Expiration { get; init; }
}