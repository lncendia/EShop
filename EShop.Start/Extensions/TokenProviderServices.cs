using EShop.Authentication.Abstractions.TokenProvider;
using EShop.Authentication.Infrastructure.TokenProvider;

namespace EShop.Start.Extensions;

public static class TokenProviderServices
{
    public static void AddTokenProvider(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration.GetRequiredValue<string>("Authentication:Issuer");
        var audience = configuration.GetRequiredValue<string>("Authentication:Audience");
        var secret = configuration.GetRequiredValue<string>("Authentication:Secret");
        var refreshTokenKey = configuration.GetRequiredValue<string>("Authentication:RefreshTokenKey");
        var accessTokenLifetime = configuration.GetRequiredValue<long>("Authentication:AccessTokenLifetime");
        var refreshTokenLifetime = configuration.GetRequiredValue<long>("Authentication:RefreshTokenLifetime");


        services.AddSingleton<ITokenProvider, TokenProvider>(_ => new TokenProvider(issuer, audience, secret,
            refreshTokenKey, TimeSpan.FromMilliseconds(refreshTokenLifetime),
            TimeSpan.FromMilliseconds(accessTokenLifetime)));
    }
}