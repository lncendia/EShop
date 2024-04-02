using EShop.Application.Abstractions.DTOs.Common;
using EShop.Application.Abstractions.DTOs.Products;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Products;

public class SearchProductsQuery : IRequest<ListDto<ProductShortDto>>
{
    public required Guid CategoryId { get; init; }
    public string? Query { get; init; }
    public IReadOnlyDictionary<string, string>? Attributes { get; init; }
    public decimal? MinPrice { get; init; }
    public decimal? MaxPrice { get; init; }
    public ProductOrder Order { get; init; }
    
    public int Skip { get; init; }
    public int Take { get; init; }
}

public enum ProductOrder
{
    Alphabet,
    AlphabetDesc,
    Price,
    PriceDesc
}