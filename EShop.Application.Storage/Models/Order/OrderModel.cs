using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Application.Storage.Models.Order;

public class OrderModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreationTime { get; set; }
    public bool IsCompleted { get; set; }
    public bool? IsSucceeded { get; set; }
    [StringLength(500)] public string? Message { get; set; }
    public Guid UserId { get; set; }
    public List<OrderItemModel> OrderItems { get; set; } = [];
    public DeliveryModel DeliveryInfo { get; set; } = null!;
    public CustomerModel CustomerInfo { get; set; } = null!;
}