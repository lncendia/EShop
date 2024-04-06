using EShop.Application.Abstractions.DTOs.Products;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Products;

public class ProductByIdQuery : IRequest<ProductDto>
{
    public Guid? UserId { get; init; }
    public required Guid Id { get; init; }
}