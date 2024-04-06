using MediatR;

namespace EShop.Application.Abstractions.Commands.Categories;

public class CreateCategoryCommand : IRequest<Guid>
{
    public required string Name { get; init; }
    public required IReadOnlyCollection<string> Attributes { get; init; }
}