using EShop.Application.Abstractions.Commands.Products;
using MediatR;

namespace EShop.Start.Initializers;

public class StovesInitializer(IServiceProvider provider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ISender>();

        foreach (var createCategoryCommand in Stoves)
        {
            await sender.Send(createCategoryCommand, stoppingToken);
        }
    }

    private static readonly Guid CategoryId = Guid.Parse("456f238f-3634-4c55-9d2a-1fcdb451cc16");

    private static readonly List<AddProductCommand> Stoves =
    [
        new AddProductCommand
        {
            Name = "GEFEST 6300-01 К13",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "GEFEST" },
                { "Тип", "газовая" },
                { "Количество конфорок", "4" },
                { "Мощность", "7 кВт" }
            },
            CategoryId = CategoryId,
            Price = 13990,
            PhotoUrl = new Uri("https://main-cdn.sbermegamarket.ru/hlr-system/197/373/436/421/718/39/100028065305b0.jpg")
        },
        new AddProductCommand
        {
            Name = "Electrolux EKC 962922 X",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Electrolux" },
                { "Тип", "электрическая" },
                { "Количество конфорок", "4" },
                { "Мощность", "9.5 кВт" }
            },
            CategoryId = CategoryId,
            Price = 21490,
            PhotoUrl = new Uri("https://bs-mag.ru/upload/iblock/0c0/0c076fe108fa628b13d3de35b69949b5.jpg")
        },
        new AddProductCommand
        {
            Name = "Bosch HXR390E10R",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Bosch" },
                { "Тип", "газовая" },
                { "Количество конфорок", "4" },
                { "Мощность", "7.5 кВт" }
            },
            CategoryId = CategoryId,
            Price = 16990,
            PhotoUrl = new Uri("https://262911.selcdn.ru/static/iblock/868/8681f6516ba9dd0ede70a6defee207fa/96052ffe6b4cabb09ab8b9bdf491421a.jpg")
        },
        new AddProductCommand
        {
            Name = "Hansa FCEW53090",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Hansa" },
                { "Тип", "электрическая" },
                { "Количество конфорок", "4" },
                { "Мощность", "7.3 кВт" }
            },
            CategoryId = CategoryId,
            Price = 11490,
            PhotoUrl = new Uri("https://e-price.ru/images/1304/1303503/elta_gp_02_nerjaveyushaya_stal.jpg")
        },
        new AddProductCommand
        {
            Name = "Kaiser EH 6425 W",
            Attributes = new Dictionary<string, string>
            {
                { "Производитель", "Kaiser" },
                { "Тип", "электрическая" },
                { "Количество конфорок", "4" },
                { "Мощность", "8.5 кВт" }
            },
            CategoryId = CategoryId,
            Price = 24990,
            PhotoUrl = new Uri("https://262911.selcdn.ru/static/iblock/8f4/8f4b199ce60de8ba777ad047d2d25d99/595f73b418f96d6dbb0c05072b2873d9.jpg")
        }
    ];
}