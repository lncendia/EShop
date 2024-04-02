using EShop.Application.Abstractions.Commands.Products;
using MediatR;

namespace EShop.Start.Initializers;

public class RefrigeratorsInitializer(IServiceProvider provider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ISender>();

        foreach (var createCategoryCommand in Refrigerators)
        {
            await sender.Send(createCategoryCommand, stoppingToken);
        }
    }

    private static readonly Guid CategoryId = Guid.Parse("841a0dc7-c6ab-46d2-b65f-8af3350b607a");

    private static readonly List<AddProductCommand> Refrigerators =
    [
        new AddProductCommand
        {
            Name = "Samsung RB33J3230SA",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Samsung" },
                { "Общий объем", "328 литров" },
                { "Объем холодильной камеры", "230 литров" },
                { "Объем морозильной камеры", "98 литров" },
                { "Энергопотребление", "35 кВт*ч" }
            },
            CategoryId = CategoryId,
            Price = 27990,
            PhotoUrl = new Uri("https://i.ebayimg.com/00/s/MTAwMFgxMDAw/z/aV0AAOSwfi1kOnmM/$_32.JPG?set_id=880000500F")
        },
        new AddProductCommand
        {
            Name = "Bosch KGN39VL21R",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Bosch" },
                { "Общий объем", "366 литров" },
                { "Объем холодильной камеры", "279 литров" },
                { "Объем морозильной камеры", "87 литров" },
                { "Энергопотребление", "40 кВт*ч" }
            },
            CategoryId = CategoryId,
            Price = 37990,
            PhotoUrl = new Uri("https://news.samsung.com/medialibrary/download/15028/large")
        },
        new AddProductCommand
        {
            Name = "LG GA-B429BLHW",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "LG" },
                { "Общий объем", "429 литров" },
                { "Объем холодильной камеры", "277 литров" },
                { "Объем морозильной камеры", "152 литра" },
                { "Энергопотребление", "45 кВт*ч" }
            },
            CategoryId = CategoryId,
            Price = 41990,
            PhotoUrl = new Uri("https://262911.selcdn.ru/static/resize_cache/563114/194ac95e42342fb639cd77807d99838e/iblock/09b/09b7806a2c596b5fd9538255b46a2ace/4b5d7f1ac555697c6e037c3f0e5914b3.jpg")
        },
        new AddProductCommand
        {
            Name = "Atlant XM 4420-100",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Atlant" },
                { "Общий объем", "356 литров" },
                { "Объем холодильной камеры", "269 литров" },
                { "Объем морозильной камеры", "87 литров" },
                { "Энергопотребление", "38 кВт*ч" }
            },
            CategoryId = CategoryId,
            Price = 20990,
            PhotoUrl = new Uri("https://import-bt.ru/upload/iblock/de1/de1bc19749356df7ee194762654bf649.jpg")
        },
        new AddProductCommand
        {
            Name = "Indesit TIAA 12 V SI",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Indesit" },
                { "Общий объем", "310 литров" },
                { "Объем холодильной камеры", "222 литра" },
                { "Объем морозильной камеры", "88 литров" },
                { "Энергопотребление", "37 кВт*ч" }
            },
            CategoryId = CategoryId,
            Price = 23990,
            PhotoUrl = new Uri("https://skidka4you.ru/image/cache/catalog/i/lf/hj/38c71e267668dcfe86de5634ce159a08-720x720.jpg")
        }
    ];
}