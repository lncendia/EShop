using System.Security.Claims;

namespace EShop.Authentication.Abstractions.TokenProvider;

public interface ITokenProvider
{
    string GenerateAccess(IEnumerable<Claim> claims);
    (string token, DateTime expiration) GenerateRefresh(Guid id);
    RefreshTokenData DecryptRefresh(string token);
}