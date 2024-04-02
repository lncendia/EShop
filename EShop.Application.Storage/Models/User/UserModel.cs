using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EShop.Application.Storage.Models.User;

public class UserModel
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
    public Guid Id { get; set; }
    public List<ShoppingCartItemModel> ShoppingCart { get; set; } = [];
    public List<FavoriteItemModel> Favorites { get; set; } = [];
}