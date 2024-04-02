using EShop.Application.Abstractions.DTOs.Products;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Products;

public class ProductByIdQuery : IRequest<ProductDto>
{
    public required Guid Id { get; init; }
}