using EShop.Application.Services.QueryHandlers.Products;
using EShop.Authentication.Services.Commands.Password;

namespace EShop.Start.Extensions;

///<summary>
/// Статический класс сервисов Mediator.
///</summary>
public static class MediatorServices
{
    ///<summary>
    /// Расширяющий метод для добавления сервисов Mediator в коллекцию служб.
    ///</summary>
    ///<param name="services">Коллекция служб.</param>
    public static void AddMediatorServices(this IServiceCollection services)
    {
        // Регистрация сервисов MediatR и обработчиков команд
        services.AddMediatR(configuration =>
        {
            configuration.RegisterServicesFromAssembly(typeof(SearchProductsQueryHandler).Assembly);
            configuration.RegisterServicesFromAssembly(typeof(RecoverPasswordCommandHandler).Assembly);
        });
    }
}