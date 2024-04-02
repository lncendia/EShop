using System.ComponentModel.DataAnnotations;
using EShop.Application.Abstractions.Queries.Products;

namespace EShop.Application.Web.Products.InputModels;

public class SearchProductsInputModel
{
    [Required] public required Guid CategoryId { get; init; }
    public string? Query { get; init; }
    public IDictionary<string, string>? Attributes { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }

    public ProductOrder Order { get; init; }

    [Range(1, 100)] public int CountPerPage { get; init; } = 15;
    [Range(1, int.MaxValue)] public int Page { get; init; } = 1;
}