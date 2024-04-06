using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace EShop.Start.Extensions;

public static class JwtAuthentication
{
    public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var issuer = configuration.GetRequiredValue<string>("Authentication:Issuer");
        var audience = configuration.GetRequiredValue<string>("Authentication:Audience");
        var secret = configuration.GetRequiredValue<string>("Authentication:Secret");

        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    // укзывает, будет ли валидироваться издатель при валидации токена
                    ValidateIssuer = true,

                    // строка, представляющая издателя
                    ValidIssuer = issuer,

                    // будет ли валидироваться потребитель токена
                    ValidateAudience = true,

                    // установка потребителя токена
                    ValidAudience = audience,

                    // будет ли валидироваться время существования
                    ValidateLifetime = true,

                    // установка ключа безопасности
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)),

                    // валидация ключа безопасности
                    ValidateIssuerSigningKey = true
                };
            });

        services.Configure<AuthenticationOptions>(options => { options.DefaultAuthenticateScheme = null; });
    }
}