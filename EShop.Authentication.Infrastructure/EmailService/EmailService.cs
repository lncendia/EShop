using EShop.Authentication.Abstractions.EmailService;
using EShop.Authentication.Abstractions.EmailService.Structs;
using EShop.Authentication.Abstractions.Exceptions;
using EShop.Authentication.Infrastructure.EmailService.Structs;
using MimeKit;

namespace EShop.Authentication.Infrastructure.EmailService;

/// <inheritdoc />
/// <summary>
/// Реализация интерфейс отправки Email
/// </summary>
/// <param name="smtpConfiguration">Конфигурация SMTP</param>
/// <param name="templateConfiguration">Настройки шаблона письма</param>
public class EmailService(EmailTemplateConfiguration templateConfiguration, SmtpConfiguration smtpConfiguration) : IEmailService
{
    /// <inheritdoc />
    /// <summary>
    /// Метод отправляет Email
    /// </summary>
    /// <param name="emailData">Объект данных об отправляемом Email</param>
    public Task SendAsync(EmailData emailData)
    {
        // Создаем посетителя
        var visitor = new EmailContentVisitor(templateConfiguration);

        // Посещаем письмо
        emailData.Accept(visitor);

        // Отправляем Email, контент берем из посетителя
        return SendEmailBySmtpAsync(emailData.Recipient, visitor.Subject!, visitor.HtmlContent!);
    }

    /// <summary>
    /// Метод отправляет Email через API MailGun
    /// </summary>
    /// <param name="recipient">Email получателя</param>
    /// <param name="subject">Тема письма</param>
    /// <param name="htmlContent">HTML контент письма</param>
    private async Task SendEmailBySmtpAsync(string recipient, string subject, string htmlContent)
    {
        try
        {
            //создаем структуру сообщения
            var message = new MimeMessage();

            //отправитель сообщения
            message.From.Add(new MailboxAddress(smtpConfiguration.DisplayedName, smtpConfiguration.Login));

            //адресат сообщения
            message.To.Add(new MailboxAddress("Customer", recipient));

            //тема сообщения
            message.Subject = subject;

            //тело сообщения (так же в формате HTML)
            message.Body = new BodyBuilder { HtmlBody = htmlContent }.ToMessageBody();

            //инициализируем клиент smtp
            using var client = new MailKit.Net.Smtp.SmtpClient();

            //либо используем порт 465
            await client.ConnectAsync(smtpConfiguration.Host, smtpConfiguration.Port, true);

            // Аутентифицируемся с помощью логина и пароля
            await client.AuthenticateAsync(smtpConfiguration.Login, smtpConfiguration.Password);

            //Асинхронно отправьте указанное сообщение
            await client.SendAsync(message);

            //Асинхронно отключить сервис
            await client.DisconnectAsync(true);
        }
        catch (Exception exception)
        {
            // Инкапсулируем полученное исключение в EmailException и вызываем его дальше
            throw new EmailSendException(exception);
        }
    }
}