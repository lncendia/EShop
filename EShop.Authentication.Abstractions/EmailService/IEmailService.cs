using EShop.Authentication.Abstractions.EmailService.Structs;

namespace EShop.Authentication.Abstractions.EmailService;

/// <summary>
/// Интерфейс отправки Email
/// </summary>
public interface IEmailService
{
    /// <summary>
    /// Метод отправляет Email
    /// </summary>
    /// <param name="emailData">Объект данных об отправляемом Email</param>
    Task SendAsync(EmailData emailData);
}