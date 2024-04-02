using EShop.Application.Storage.Context;
using EShop.Application.Storage.Extensions;
using EShop.Application.Storage.Mappers.Abstractions;
using EShop.Application.Storage.Models.Product;
using EShop.Domain.ProductAggregate;
using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Mappers.ModelMappers;

internal class ProductModelMapper(ApplicationDbContext context) : IModelMapperUnit<ProductModel, Product>
{
    public async Task<ProductModel> MapAsync(Product aggregate)
    {
        var model = await context.Products
            .LoadDependencies()
            .FirstOrDefaultAsync(x => x.Id == aggregate.Id) ?? new ProductModel { Id = aggregate.Id };

        model.Name = aggregate.Name;
        model.Price = aggregate.Price;
        model.Count = aggregate.Count;
        model.CategoryId = aggregate.CategoryId;
        model.PhotoUrl = aggregate.PhotoUrl;

        ProcessAttributes(aggregate, model);

        return model;
    }

    private static void ProcessAttributes(Product aggregate, ProductModel model)
    {
        model.Attributes.RemoveAll(x => aggregate.Attributes.All(m => m.Key != x.Name));
        
        var newAttributes = aggregate.Attributes
            .Where(x => model.Attributes.All(m => m.Name != x.Key))
            .Select(x => new AttributeModel
            {
                Name = x.Key,
                Value = x.Value,
            });
        
        model.Attributes.AddRange(newAttributes);
    }
}