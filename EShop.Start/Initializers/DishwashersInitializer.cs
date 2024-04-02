using EShop.Application.Abstractions.Commands.Products;
using MediatR;

namespace EShop.Start.Initializers;

public class DishwashersInitializer(IServiceProvider provider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ISender>();

        foreach (var createCategoryCommand in Dishwashers)
        {
            await sender.Send(createCategoryCommand, stoppingToken);
        }
    }

    private static readonly Guid CategoryId = Guid.Parse("775e4f10-41a0-4dd7-8702-e6fcec637ac8");

    private static readonly List<AddProductCommand> Dishwashers =
    [
        new AddProductCommand
        {
            Name = "Hansa ZIM436E",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Hansa" },
                { "Вместимость", "14 комплектов" },
                { "Энергопотребление", "A++" }
            },
            CategoryId = CategoryId,
            Price = 23990,
            PhotoUrl = new Uri("https://www.premier-techno.ru/upload/iblock/df7/df7ea400b70eeb25d286537f3f2ff860.jpg")
        },
        new AddProductCommand
        {
            Name = "Bosch SMS25AW01R",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Bosch" },
                { "Вместимость", "12 комплектов" },
                { "Энергопотребление", "A+" }
            },
            CategoryId = CategoryId,
            Price = 24990,
            PhotoUrl = new Uri("https://a.allegroimg.com/s1024/0c4c0f/be4bec46409290adc400713d4907")
        },
        new AddProductCommand
        {
            Name = "Electrolux ESF5533LOW",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Electrolux" },
                { "Вместимость", "13 комплектов" },
                { "Энергопотребление", "A++" }
            },
            CategoryId = CategoryId,
            Price = 29990,
            PhotoUrl = new Uri("https://i.ebayimg.com/00/s/MTYwMFgxNjAw/z/C34AAOSwyfpffPIt/$_3.JPG?set_id=2")
        },
        new AddProductCommand
        {
            Name = "Siemens SN215W02AE",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Siemens" },
                { "Вместимость", "12 комплектов" },
                { "Энергопотребление", "A+" }
            },
            CategoryId = CategoryId,
            Price = 31490,
            PhotoUrl = new Uri("https://runeco.ru/wa-data/public/shop/products/63/74/27463/images/35553/35553.750x0.jpg")
        },
        new AddProductCommand
        {
            Name = "Gorenje GV 55240",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Gorenje" },
                { "Вместимость", "12 комплектов" },
                { "Энергопотребление", "A++" }
            },
            CategoryId = CategoryId,
            Price = 28990,
            PhotoUrl = new Uri("https://runeco.ru/wa-data/public/shop/products/20/12/41220/images/64469/64469.750x0.jpeg")
        }
    ];
}