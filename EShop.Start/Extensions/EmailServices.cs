using EShop.Authentication.Abstractions.EmailService;
using EShop.Authentication.Infrastructure.EmailService;
using EShop.Authentication.Infrastructure.EmailService.Structs;
using EShop.Start.Exceptions;

namespace EShop.Start.Extensions;

/// <summary> 
/// Статический класс, содержащий методы для работы с электронной почтой. 
/// </summary> 
public static class EmailServices
{
    /// <summary>
    /// Метод для добавления службы электронной почты в коллекцию служб.
    /// </summary>
    /// <param name="services">Коллекция служб.</param>
    /// <param name="configuration">Конфигурация приложения.</param>
    public static void AddEmailServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Получаем конфигурацию для smtp из конфигурации приложения
        var smtpConfiguration = GetEmailConfiguration(configuration);

        // Получаем конфигурацию для шаблона письма конфигурации приложения
        var templateConfiguration = GetTemplateConfiguration(configuration);

        // Регистрируем одиночный экземпляр интерфейса IEmailService с реализацией EmailService.
        services.AddSingleton<IEmailService>(sp => new EmailService(templateConfiguration, smtpConfiguration));
    }

    /// <summary>
    /// Метод генерирует SMTP настройки системных Email
    /// </summary>
    /// <param name="configuration">Конфигурация приложения</param>
    /// <returns>Коллекция SMTP настроек системных Email</returns>
    private static SmtpConfiguration GetEmailConfiguration(IConfiguration configuration)
    {
        // Получаем секцию с настройками SMTP
        var smtpConfigurationSection = configuration.GetSection("EmailSettings:SmtpSettings");

        // Если секции конфигурации нет - вызываем исключение
        if (smtpConfigurationSection == null) throw new ConfigurationException("EmailSettings:SmtpSettings");

        // Получаем данные из конфигурации
        var smtpHost = smtpConfigurationSection.GetRequiredValue<string>("Host");
        var smtpPort = smtpConfigurationSection.GetRequiredValue<int>("Port");
        var smtpLogin = smtpConfigurationSection.GetRequiredValue<string>("Email");
        var smtpPassword = smtpConfigurationSection.GetRequiredValue<string>("Password");
        var displayedName = smtpConfigurationSection.GetRequiredValue<string>("DisplayedName");

        //создаем объект данных об SMTP настройках
        return new SmtpConfiguration
        {
            // Хост
            Host = smtpHost,

            // Порт
            Port = smtpPort,

            // Логин
            Login = smtpLogin,

            // Пароль
            Password = smtpPassword,

            // Отображаемое имя
            DisplayedName = displayedName
        };
    }


    /// <summary>
    /// Метод генерирует настройки для шаблона электронного письма
    /// </summary>
    /// <param name="configuration">Конфигурация приложения</param>
    /// <returns>Настройки для шаблона электронного письма</returns>
    private static EmailTemplateConfiguration GetTemplateConfiguration(IConfiguration configuration)
    {
        // Получаем секцию с настройками шаблона письма
        var templateConfigurationSection = configuration.GetSection("EmailSettings:TemplateSettings");

        // Если секции конфигурации нет - вызываем исключение
        if (templateConfigurationSection == null) throw new ConfigurationException("EmailSettings:TemplateSettings");

        // Получаем данные из конфигурации
        var companyName = templateConfigurationSection.GetRequiredValue<string>("CompanyName");
        var logoLink = templateConfigurationSection.GetRequiredValue<string>("LogoLink");
        var privatePolicyLink = templateConfigurationSection.GetRequiredValue<string>("PrivatePolicyLink");
        var homePageLink = templateConfigurationSection.GetRequiredValue<string>("HomePageLink");
        var sideLogoLink = templateConfigurationSection.GetRequiredValue<string>("SideLogoLink");

        //создаем объект данных об настройках шаблона письма
        return new EmailTemplateConfiguration
        {
            // Имя компании
            CompanyName = companyName,
            
            // Ссылка на лого компании
            LogoLink = logoLink,
            
            // Ссылка на страницу приватной политики
            PrivatePolicyLink = privatePolicyLink,
            
            // Ссылка на домашнюю страницу
            HomePageLink = homePageLink,
            
            // Ссылка на вторичное лого компании
            SideLogoLink = sideLogoLink
        };
    }
}