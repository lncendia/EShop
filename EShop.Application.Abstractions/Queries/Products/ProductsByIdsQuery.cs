using EShop.Application.Abstractions.DTOs.Products;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Products;

public class ProductsByIdsQuery : IRequest<ProductDto[]>
{
    public Guid? UserId { get; init; }
    public required Guid[] Ids { get; init; }
}