using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Models.Order;

[PrimaryKey(nameof(ProductId), nameof(OrderId))]
public class OrderItemModel
{
    public Guid ProductId { get; set; }
    public Guid OrderId { get; set; }
    public int Count { get; set; }
}