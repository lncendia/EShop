using System.ComponentModel.DataAnnotations;

namespace EShop.Application.Storage.Models.Order;

public class CustomerModel
{
    [StringLength(100)] public required string Name { get; set; } = null!;

    [StringLength(100)] public string PhoneNumber { get; set; } = null!;

    [StringLength(100)] public string Email { get; set; } = null!;
}