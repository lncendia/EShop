using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Storage.Models.Order;

public class DeliveryModel
{
    [StringLength(400)] public string Region { get; set; } = null!;

    [StringLength(400)] public string City { get; set; } = null!;

    [StringLength(400)] public string Street { get; set; } = null!;

    [StringLength(10)] public string Building { get; set; } = null!;

    [StringLength(10)] public string? Apartment { get; set; } = null!;

    [StringLength(400)] public string? Comment { get; set; }

    public int? Flat { get; set; }
}