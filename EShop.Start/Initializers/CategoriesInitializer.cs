using EShop.Application.Abstractions.Commands.Categories;
using MediatR;

namespace EShop.Start.Initializers;

public class CategoriesInitializer(IServiceProvider provider) : BackgroundService
{
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        using var scope = provider.CreateScope();
        var sender = scope.ServiceProvider.GetRequiredService<ISender>();

        foreach (var createCategoryCommand in Categories)
        {
            await sender.Send(createCategoryCommand, stoppingToken);
        }
    }

    private static readonly List<CreateCategoryCommand> Categories =
    [
        new CreateCategoryCommand
        {
            Name = "Холодильники",
            Attributes =
            [
                "Производитель",
                "Общий объем",
                "Объем холодильной камеры",
                "Объем морозильной камеры",
                "Энергопотребление"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Плиты",
            Attributes =
            [
                "Производитель",
                "Тип",
                "Количество конфорок",
                "Мощность"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Микроволновые печи",
            Attributes =
            [
                "Производитель",
                "Объем внутреннего пространства",
                "Мощность",
                "Наличие гриля",
                "Тип управления"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Посудомоечные машины",
            Attributes =
            [
                "Производитель",
                "Вместимость",
                "Энергопотребление"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Кофемашины",
            Attributes =
            [
                "Производитель",
                "Тип",
                "Давление насоса",
                "Объем бойлера/резервуара для воды"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Утюги",
            Attributes =
            [
                "Производитель",
                "Мощность",
                "Тип подошвы",
                "Режимы утюжения",
                "Паровая функция"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Пылесосы",
            Attributes =
            [
                "Производитель",
                "Мощность",
                "Тип пылесборника",
                "Фильтрация",
                "Длина шнура"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Миксеры/блендеры",
            Attributes =
            [
                "Производитель",
                "Мощность",
                "Количество скоростей",
                "Тип насадок/лезвий",
                "Материал корпуса"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Электрические чайники",
            Attributes =
            [
                "Производитель",
                "Объем",
                "Мощность",
                "Материал корпуса",
                "Автоматическое отключение"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Варочные панели",
            Attributes =
            [
                "Производитель",
                "Тип",
                "Количество конфорок",
                "Размеры",
                "Управление"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Тостеры",
            Attributes =
            [
                "Производитель",
                "Количество слотов",
                "Функции",
                "Мощность",
                "Материал корпуса"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Мясорубки",
            Attributes =
            [
                "Производитель",
                "Мощность",
                "Вместимость загрузки",
                "Типы насадок",
                "Материал корпуса"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Фритюрницы",
            Attributes =
            [
                "Производитель",
                "Объем",
                "Мощность",
                "Температурные режимы",
                "Материал корпуса"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Электрочайники",
            Attributes =
            [
                "Производитель",
                "Объем",
                "Мощность",
                "Материал корпуса",
                "Автоматическое отключение"
            ]
        },
        new CreateCategoryCommand
        {
            Name = "Блендеры",
            Attributes =
            [
                "Производитель",
                "Мощность",
                "Объем контейнера",
                "Тип лезвий",
                "Материал корпуса"
            ]
        }
    ];
}