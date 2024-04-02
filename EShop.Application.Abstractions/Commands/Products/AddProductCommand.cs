using MediatR;

namespace EShop.Application.Abstractions.Commands.Products;

public class AddProductCommand : IRequest<Guid>
{
    public required Guid CategoryId { get; init; }
    public Uri? PhotoUrl { get; init; }
    public string? PhotoBase64 { get; init; }
    public required string Name { get; init; }
    public required decimal Price { get; init; }
    public required IReadOnlyDictionary<string, string> Attributes { get; init; }
}