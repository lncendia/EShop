using EShop.Application.Abstractions.DTOs.Categories;
using EShop.Application.Abstractions.Queries.Categories;
using EShop.Application.Web.Categories.ViewModels;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EShop.Application.Web.Categories.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ISender sender) : ControllerBase
{
    [HttpGet]
    [Route("{id:guid}")]
    public async Task<CategoryViewModel> Get(Guid id)
    {
        var category = await sender.Send(new CategoryByIdQuery { Id = id });
        return Map(category);
    }

    [HttpGet]
    public async Task<IEnumerable<CategoryShortViewModel>> Get()
    {
        var categories = await sender.Send(new CategoriesQuery());
        return categories.Select(Map);
    }


    private static CategoryShortViewModel Map(CategoryShortDto dto) => new()
    {
        Name = dto.Name,
        Id = dto.Id
    };

    private static CategoryViewModel Map(CategoryDto dto) => new()
    {
        Name = dto.Name,
        Id = dto.Id,
        Attributes = dto.Attributes.Select(a => new AttributeViewModel
        {
            Name = a.Name,
            Values = a.Values.Select(v => new AttributeValueViewModel
            {
                Value = v.Value,
                Count = v.Count
            })
        })
    };
}