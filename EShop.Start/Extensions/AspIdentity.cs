using EShop.Authentication.Abstractions.Models;
using EShop.Authentication.Infrastructure.DbContexts;
using EShop.Authentication.Services.Validators;
using Microsoft.AspNetCore.Identity;

namespace EShop.Start.Extensions;

/// <summary>
/// Статический класс, представляющий методы для добавления ASP.NET Identity.
/// </summary>
public static class AspIdentity
{
    /// <summary>
    /// Добавляет ASP.NET Identity в коллекцию сервисов.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    public static void AddAspIdentity(this IServiceCollection services)
    {
        // Добавляет валидатор для пользователя.
        services.AddTransient<IUserValidator<User>, CustomUserValidator>();

        // Добавляет валидатор для пароля.
        services.AddTransient<IPasswordValidator<User>, CustomPasswordValidator>();

        /* Добавляет и настраивает идентификационную систему для
         указанных пользователей и типов ролей.
         Устанавливает опции блокировки учетных записей. */
        services.AddIdentity<User, Role>(opt =>
            {
                // Разрешает применение механизма блокировки для новых пользователей.
                opt.Lockout.AllowedForNewUsers = true;

                // Задает временной интервал блокировки по умолчанию в 15 минут
                opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);

                // Устанавливает максимальное количество неудачных попыток входа перед блокировкой
                opt.Lockout.MaxFailedAccessAttempts = 10;

                opt.ClaimsIdentity.UserIdClaimType = "sub";
                opt.ClaimsIdentity.UserNameClaimType = "name";
                opt.ClaimsIdentity.RoleClaimType = "role";
                opt.ClaimsIdentity.EmailClaimType = "email";
            })

            //Добавляет реализацию Entity Framework хранилищ сведений об удостоверениях.
            .AddEntityFrameworkStores<AuthenticationDbContext>()

            // Добавляет поставщиков токенов по умолчанию, используемых для
            // создания токенов для сброса паролей, операций изменения
            // электронной почты и номера телефона, а также для создания токенов
            // двухфакторной аутентификации.
            .AddDefaultTokenProviders();
    }
}