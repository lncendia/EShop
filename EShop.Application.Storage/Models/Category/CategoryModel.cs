using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Application.Storage.Models.Category;

public class CategoryModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [StringLength(50)] public string Name { get; set; } = null!;

    public List<AttributeModel> Attributes { get; set; } = [];
}