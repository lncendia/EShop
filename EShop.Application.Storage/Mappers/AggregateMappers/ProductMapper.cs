using System.Reflection;
using System.Runtime.CompilerServices;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Mappers.StaticMethods;
using EShop.Application.Storage.Models.Product;
using EShop.Domain.Abstractions;
using EShop.Domain.ProductAggregate;

namespace EShop.Application.Storage.Mappers.AggregateMappers;

internal class ProductMapper : IAggregateMapperUnit<Product, ProductModel>
{
    private static readonly Type ProductType = typeof(Product);
    
    private static readonly FieldInfo Attributes =
        ProductType.GetField("<Attributes>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;
    
    private static readonly FieldInfo CategoryId =
        ProductType.GetField("<CategoryId>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;
    
    private static readonly FieldInfo PhotoUrl =
        ProductType.GetField("<PhotoUrl>k__BackingField", BindingFlags.Instance | BindingFlags.NonPublic)!;
    
    private static readonly FieldInfo Count =
        ProductType.GetField("_count", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo Price =
        ProductType.GetField("_cost", BindingFlags.Instance | BindingFlags.NonPublic)!;

    private static readonly FieldInfo Name =
        ProductType.GetField("_name", BindingFlags.Instance | BindingFlags.NonPublic)!;


    public Product Map(ProductModel model)
    {
        var product = (Product)RuntimeHelpers.GetUninitializedObject(ProductType);
        Count.SetValue(product, model.Count);
        Price.SetValue(product, model.Price);
        Name.SetValue(product, model.Name);
        PhotoUrl.SetValue(product, model.PhotoUrl);
        CategoryId.SetValue(product, model.CategoryId);
        Attributes.SetValue(product, model.Attributes.ToDictionary(x=>x.Name, x=>x.Value));
        
        IdFields.AggregateId.SetValue(product, model.Id);
        IdFields.DomainEvents.SetValue(product, new List<IDomainEvent>());
        return product;
    }
}