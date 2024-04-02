using EShop.Application.Storage.Models.Category;
using EShop.Application.Storage.Models.Order;
using EShop.Application.Storage.Models.Product;
using EShop.Application.Storage.Models.User;
using MediatR;
using Microsoft.EntityFrameworkCore;
using CategoryAttribute = EShop.Application.Storage.Models.Category.AttributeModel;
using ProductAttribute  = EShop.Application.Storage.Models.Product.AttributeModel;

namespace EShop.Application.Storage.Context;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureOrder();
        modelBuilder.ConfigureUser();
        modelBuilder.ConfigureCategory();
        modelBuilder.ConfigureProduct();
        base.OnModelCreating(modelBuilder);
    }

    public List<INotification> Notifications { get; } = [];
    public DbSet<CategoryModel> Categories { get; set; } = null!;
    public DbSet<CategoryAttribute> CategoryAttributes { get; set; } = null!;
    public DbSet<AttributeValueModel> AttributeValues { get; set; } = null!;
    public DbSet<OrderModel> Orders { get; set; } = null!;
    public DbSet<OrderItemModel> OrderItems { get; set; } = null!;
    public DbSet<ProductModel> Products { get; set; } = null!;
    public DbSet<ProductAttribute> ProductAttributes { get; set; } = null!;
    public DbSet<UserModel> Users { get; set; } = null!;
    public DbSet<ShoppingCartItemModel> UserShoppingCart { get; set; } = null!;
    public DbSet<FavoriteItemModel> UserFavorites { get; set; } = null!;
    
}