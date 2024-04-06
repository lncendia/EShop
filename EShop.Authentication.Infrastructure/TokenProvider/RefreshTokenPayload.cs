namespace EShop.Authentication.Infrastructure.TokenProvider;

public class RefreshTokenPayload
{
    public required Guid Id { get; init; }
    public required DateTime Expiration { get; init; }
}