using EShop.Application.Abstractions.DTOs.Products;
using EShop.Application.Abstractions.Queries.Products;
using EShop.Application.Web.Common.Enums;
using EShop.Application.Web.Common.ViewModels;
using EShop.Application.Web.Products.InputModels;
using EShop.Application.Web.Products.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Application.Web.Products.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public class ProductController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<ProductViewModel> Get(Guid id)
    {
        var product = await sender.Send(new ProductByIdQuery { Id = id, UserId = GetUserId()});
        return Map(product);
    }

    [HttpPost]
    public async Task<ListViewModel<ProductViewModel>> Search(SearchProductsInputModel model)
    {
        var data = await sender.Send(new SearchProductsQuery
        {
            UserId = GetUserId(),
            CategoryId = model.CategoryId,
            Attributes = model.Attributes?.Select(a => new AttributeQuery
            {
                Name = a.Name!,
                Values = a.Values!
            }).ToArray(),
            MinPrice = model.MinPrice,
            MaxPrice = model.MaxPrice,
            Order = model.Order,
            Query = model.Query,
            Skip = (model.Page - 1) * model.CountPerPage,
            Take = model.CountPerPage
        });

        var count = data.TotalCount / model.CountPerPage;
        if (data.TotalCount % model.CountPerPage > 0) count++;
        return new ListViewModel<ProductViewModel>
        {
            TotalPages = count,
            List = data.List.Select(Map)
        };
    }

    [HttpGet]
    public async Task<IEnumerable<ProductViewModel>> GetByIds([FromQuery] Guid[] ids)
    {
        var products = await sender.Send(new ProductsByIdsQuery
        {
            UserId = GetUserId(),
            Ids = ids.Take(10).ToArray()
        });

        return products.Select(Map);
    }

    private ProductViewModel Map(ProductDto product) => new()
    {
        Id = product.Id,
        PhotoUrl = $"{Request.Scheme}://{Request.Host}/{product.PhotoUrl.ToString().Replace('\\', '/')}",
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        CountType = GetCountType(product.Count),
        Attributes = product.Attributes,
        CategoryId = product.CategoryId,
        CategoryName = product.CategoryName,
        InFavorite = product.InFavorite,
        InShoppingCart = product.InShoppingCart
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

    private Guid? GetUserId() => User.Identity?.IsAuthenticated ?? false ? User.Id() : null;
}