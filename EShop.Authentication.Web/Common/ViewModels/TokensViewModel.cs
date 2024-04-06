namespace EShop.Authentication.Web.Common.ViewModels;

public class TokensViewModel
{
    public required string AccessToken { get; init; }
    public required string RefreshToken { get; init; }
    public required DateTime RefreshTokenExpiration { get; init; }
}