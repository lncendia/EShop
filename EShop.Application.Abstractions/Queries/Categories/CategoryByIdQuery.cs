using EShop.Application.Abstractions.DTOs.Categories;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Categories;

public class CategoryByIdQuery : IRequest<CategoryDto>
{
    public required Guid Id { get; init; }
}