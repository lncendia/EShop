using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Storage.Models.Product;

public class AttributeModel
{
    [Key] public long Id { get; set; }
    [StringLength(50)] public string Name { get; set; } = null!;
    [StringLength(500)] public string Value { get; set; } = null!;
    public Guid ProductId { get; set; }
}