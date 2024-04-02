using Microsoft.EntityFrameworkCore;

namespace EShop.Application.Storage.Models.User;

[PrimaryKey(nameof(UserId), nameof(ProductId))]
public class FavoriteItemModel
{
    public Guid UserId { get; set; }
    public Guid ProductId { get; set; }
}