using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Category;
using EShop.Domain.CategoryAggregate;
using Microsoft.EntityFrameworkCore;
using Attribute = EShop.Domain.CategoryAggregate.Entities.Attribute;

namespace EShop.Application.Storage.Mappers.ModelMappers;

internal class CategoryModelMapper(ApplicationDbContext context) : IModelMapperUnit<CategoryModel, Category>
{
    public async Task<CategoryModel> MapAsync(Category aggregate)
    {
        var model = await context.Categories
                        .LoadDependencies()
                        .FirstOrDefaultAsync(x => x.Id == aggregate.Id) ??
                    new CategoryModel { Id = aggregate.Id };
        model.Name = aggregate.Name;
        ProcessAttributes(aggregate, model);
        return model;
    }

    private static void ProcessAttributes(Category aggregate, CategoryModel model)
    {
        model.Attributes.RemoveAll(x => aggregate.Attributes.All(m => m.Name != x.Name));

        var newAttributes = aggregate.Attributes
            .Where(x => model.Attributes.All(m => m.Name != x.Name))
            .Select(x => new AttributeModel { Name = x.Name })
            .ToArray();

        foreach (var attribute in model.Attributes)
        {
            ProcessAttribute(aggregate.Attributes.First(c => c.Name == attribute.Name), attribute);
        }

        foreach (var attribute in newAttributes)
        {
            ProcessAttribute(aggregate.Attributes.First(c => c.Name == attribute.Name), attribute);
        }

        model.Attributes.AddRange(newAttributes);
    }

    private static void ProcessAttribute(Attribute aggregate, AttributeModel model)
    {
        model.Name = aggregate.Name;

        model.Values.RemoveAll(x => aggregate.Values.All(m => m.Value != x.Value));

        var newValues = aggregate.Values
            .Where(x => model.Values.All(m => m.Value != x.Value))
            .Select(x => new AttributeValueModel
            {
                Value = x.Value,
                Count = x.Count
            });

        foreach (var value in model.Values)
        {
            var agValue = aggregate.Values.First(c => c.Value == value.Value);
            value.Count = agValue.Count;
        }

        model.Values.AddRange(newValues);
    }
}