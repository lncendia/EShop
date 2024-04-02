using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Storage.Models.Category;

public class AttributeValueModel
{
    [Key] public long Id { get; set; }
    public long AttributeId { get; set; }
    [StringLength(500)] public string Value { get; set; } = null!;
    public int Count { get; set; }
}