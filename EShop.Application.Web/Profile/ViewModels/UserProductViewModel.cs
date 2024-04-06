using EShop.Application.Web.Common.Enums;

namespace EShop.Application.Web.Profile.ViewModels;

public class UserProductViewModel
{
    public required Guid Id { get; init; }
    public required string Name { get; init; }
    public required string CategoryName { get; init; }
    public required string Description { get; init; }
    public required string PhotoUrl { get; init; }
    public required decimal Price { get; init; }
    
    public required CountType CountType { get; init; }
}