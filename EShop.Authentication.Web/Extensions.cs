using System.Security.Claims;

namespace EShop.Authentication.Web;

/// <summary>
/// Расширения для работы с аутентификацией
/// </summary>
public static class Extensions
{
    /// <summary>
    /// Возвращает идентификатор пользователя из объекта ClaimsPrincipal.
    /// </summary>
    /// <param name="principal">Объект ClaimsPrincipal.</param>
    /// <returns>Идентификатор пользователя.</returns>
    public static Guid Id(this ClaimsPrincipal principal) => Guid.Parse(principal.FindFirstValue("sub")!);
}