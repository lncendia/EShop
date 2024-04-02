using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Storage.Models.Category;

public class AttributeModel
{
    [Key] public long Id { get; set; }
    [StringLength(50)] public string Name { get; set; } = null!;
    public Guid CategoryId { get; set; }
    public List<AttributeValueModel> Values { get; set; } = [];
}