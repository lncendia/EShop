using System.Security.Claims;

namespace EShop.Authentication.Abstractions.JwtGenerator;

public interface IJwtGenerator
{
    Task<string> GenerateAsync(IEnumerable<Claim> claims);
}