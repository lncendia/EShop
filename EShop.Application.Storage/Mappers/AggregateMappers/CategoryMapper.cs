using System.Reflection;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Mappers.StaticMethods;
using EShop.Application.Storage.Models.Category;
using EShop.Domain.CategoryAggregate;
using EShop.Domain.CategoryAggregate.ValueObjects;
using Attribute = EShop.Domain.CategoryAggregate.Entities.Attribute;

namespace EShop.Application.Storage.Mappers.AggregateMappers;

internal class CategoryMapper : IAggregateMapperUnit<Category, CategoryModel>
{
    private static readonly Type CategoryType = typeof(Category);
    private static readonly Type AttributeType = typeof(Attribute);

    private static readonly FieldInfo Attributes =
        CategoryType.GetField("_attributes", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo Values =
        AttributeType.GetField("_values", BindingFlags.Instance | BindingFlags.NonPublic)!;

    public Category Map(CategoryModel model)
    {
        var category = new Category(model.Attributes.Select(a => a.Name))
        {
            Name = model.Name
        };

        var attributes = (List<Attribute>)Attributes.GetValue(category)!;

        foreach (var attribute in attributes)
        {
            var modelAttribute = model.Attributes.First(a => a.Name == attribute.Name);
            var values = (List<AttributeValue>)Values.GetValue(attribute)!;
            values.AddRange(modelAttribute.Values
                .Select(a => new AttributeValue { Value = a.Value, Count = a.Count }));
        }
        IdFields.AggregateId.SetValue(category, model.Id);
        return category;
    }
}