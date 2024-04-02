using EShop.Application.Storage.DatabaseInitialization;
using EShop.Start.Extensions;
using EShop.Start.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddMemoryCache();

builder.Services.AddCorsServices();

builder.Services.AddMediatorServices();

// Добавление служб для хранилища
builder.Services.AddPersistenceServices(builder.Configuration, builder.Environment.WebRootPath);

// Регистрация контроллеров с поддержкой сериализации JSON
builder.Services.AddControllers();

// Добавление служб для работы с CORS
builder.Services.AddCorsServices();

builder.Services.AddSwaggerGen();

// builder.Services.AddHostedService<DishwashersInitializer>();

// Создание приложения на основе настроек builder
await using var app = builder.Build();

// Создаем область для инициализации баз данных
using (var scope = app.Services.CreateScope())
{
    // Инициализация начальных данных в базу данных
    await DatabaseInitializer.InitAsync(scope.ServiceProvider);
}

// Добавляем мидлварь обработки ошибок
app.UseMiddleware<ExceptionMiddleware>();

// Использование Swagger для обслуживания документации по API
app.UseSwagger();

// Использование SwaggerServices UI для предоставления интерактивной документации по API
app.UseSwaggerUI(c =>
{
    // Настройте Swagger UI для использования OAuth2
    c.OAuthClientId("swagger");
    c.OAuthUsePkce(); // Используйте PKCE (Proof Key for Code Exchange) с авторизационным кодом
});

app.UseStaticFiles();

// Использование политик Cors
app.UseCors("DefaultPolicy");

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

// Запуск приложения
await app.RunAsync();