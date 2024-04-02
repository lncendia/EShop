using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Web.Common.ViewModels;
using EShop.Application.Web.Products.InputModels;
using EShop.Application.Web.Products.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Application.Web.Products.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ProductViewModel> Get(Guid id)
    {
        var product = await sender.Send(new ProductByIdQuery { Id = id });
        return Map(product);
    }

    [HttpGet]
    public async Task<ListViewModel<ProductShortViewModel>> Get([FromQuery] SearchProductsInputModel model)
    {
        var data = await sender.Send(new SearchProductsQuery
        {
            CategoryId = model.CategoryId,
            Attributes = model.Attributes?.AsReadOnly(),
            MinPrice = model.MinPrice,
            MaxPrice = model.MaxPrice,
            Order = model.Order,
            Query = model.Query,
            Skip = (model.Page - 1) * model.CountPerPage,
            Take = model.CountPerPage
        });
        
        var count = data.TotalCount / model.CountPerPage;
        if (data.TotalCount % model.CountPerPage > 0) count++;
        return new ListViewModel<ProductShortViewModel>
        {
            TotalPages = count,
            List = data.List.Select(Map)
        };
    }

    private static ProductShortViewModel Map(ProductShortDto product) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl.ToString().Replace('\\', '/'),
        Name = product.Name,
        Price = product.Price,
        CountType = GetCountType(product.Count)
    };
    
    private static ProductViewModel Map(ProductDto product) => new()
    {
        Id = product.Id,
        PhotoUrl = product.PhotoUrl.ToString().Replace('\\', '/'),
        Name = product.Name,
        Price = product.Price,
        CountType = GetCountType(product.Count),
        Attributes = product.Attributes,
        CategoryId = product.CategoryId,
    };

    private static CountType GetCountType(int count)
    {
        return count switch
        {
            > 10 => CountType.Available,
            > 0 => CountType.Close,
            _ => CountType.OutOfStock
        };
    }
}