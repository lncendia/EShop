using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using EShop.Authentication.Abstractions.TokenProvider;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;

namespace EShop.Authentication.Infrastructure.TokenProvider;

public class TokenProvider : ITokenProvider, IDisposable
{
    private readonly JwtSecurityTokenHandler _handler = new();

    private readonly string _issuer;
    private readonly string _audience;
    private readonly string _refreshTokenKey;
    private readonly SigningCredentials _credentials;
    private readonly SymmetricAlgorithm _algorithm;
    private readonly TimeSpan _refreshTokenLifetime;
    private readonly TimeSpan _accessTokenLifetime;

    public TokenProvider(string issuer, string audience, string secretKey, string refreshTokenKey,
        TimeSpan refreshTokenLifetime, TimeSpan accessTokenLifetime)
    {
        _issuer = issuer;
        _audience = audience;
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
        _credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        _algorithm = Aes.Create();
        _refreshTokenKey = refreshTokenKey;
        _refreshTokenLifetime = refreshTokenLifetime;
        _accessTokenLifetime = accessTokenLifetime;
    }

    public string GenerateAccess(IEnumerable<Claim> claims)
    {
        var accessToken = new JwtSecurityToken(
            issuer: _issuer,
            audience: _audience,
            claims: claims,
            expires: DateTime.Now.Add(_accessTokenLifetime),
            signingCredentials: _credentials);

        return _handler.WriteToken(accessToken);
    }

    public RefreshTokenData DecryptRefresh(string token)
    {
        var refreshTokenJson = Decrypt(token);
        var refreshTokenPayload = JsonConvert.DeserializeObject<RefreshTokenPayload>(refreshTokenJson)!;
        return new RefreshTokenData
        {
            Id = refreshTokenPayload.Id,
            Expiration = refreshTokenPayload.Expiration
        };
    }

    public (string token, DateTime expiration) GenerateRefresh(Guid id)
    {
        var refreshTokenPayload = new RefreshTokenPayload
        {
            Id = id,
            Expiration = DateTime.Now.Add(_refreshTokenLifetime)
        };

        var refreshTokenJson = JsonConvert.SerializeObject(refreshTokenPayload);
        var token = Encrypt(refreshTokenJson);
        return (token, refreshTokenPayload.Expiration);
    }

    private string Encrypt(string data)
    {
        var key = Encoding.UTF8.GetBytes(_refreshTokenKey);
        using var encryptor = _algorithm.CreateEncryptor(key, _algorithm.IV);

        var dataBytes = Encoding.UTF8.GetBytes(data);
        var encryptedData = encryptor.TransformFinalBlock(dataBytes, 0, dataBytes.Length);

        return Convert.ToBase64String(encryptedData);
    }

    private string Decrypt(string encryptedData)
    {
        var key = Encoding.UTF8.GetBytes(_refreshTokenKey);
        using var decryptor = _algorithm.CreateDecryptor(key, _algorithm.IV);

        var encryptedDataBytes = Convert.FromBase64String(encryptedData);
        var decryptedData = decryptor.TransformFinalBlock(encryptedDataBytes, 0, encryptedDataBytes.Length);

        return Encoding.UTF8.GetString(decryptedData);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
        _algorithm.Dispose();
    }
}