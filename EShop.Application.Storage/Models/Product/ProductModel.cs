using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Application.Storage.Models.Product;

public class ProductModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }

    [StringLength(50)] public string Name { get; set; } = null!;
    [StringLength(500)] public string Description { get; set; } = null!;

    public decimal Price { get; set; }

    public int Count { get; set; }

    public Uri PhotoUrl { get; set; } = null!;

    public Guid CategoryId { get; set; }

    public List<AttributeModel> Attributes { get; set; } = [];
}