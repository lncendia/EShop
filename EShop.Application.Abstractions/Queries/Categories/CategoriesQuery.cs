using EShop.Application.Abstractions.DTOs.Categories;
using MediatR;

namespace EShop.Application.Abstractions.Queries.Categories;

public class CategoriesQuery : IRequest<IReadOnlyCollection<CategoryDto>>;