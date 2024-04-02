using EShop.Application.Storage.Models.Category;
using EShop.Application.Storage.Models.Order;
using EShop.Application.Storage.Models.Product;
using EShop.Application.Storage.Models.User;
using Microsoft.EntityFrameworkCore;
using CategoryAttribute = EShop.Application.Storage.Models.Category.AttributeModel;

namespace EShop.Application.Storage.Context;

public static class FluentExtensions
{
    public static void ConfigureCategory(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoryModel>()
            .HasMany(c => c.Attributes)
            .WithOne()
            .HasForeignKey(a => a.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<CategoryAttribute>()
            .HasMany(a => a.Values)
            .WithOne()
            .HasForeignKey(v => v.AttributeId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public static void ConfigureOrder(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<OrderModel>()
            .HasOne<UserModel>()
            .WithMany()
            .HasForeignKey(o => o.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<OrderModel>()
            .Property(p => p.TotalPrice)
            .HasColumnType("numeric(18, 2)");

        modelBuilder.Entity<OrderModel>()
            .HasMany(o => o.OrderItems)
            .WithOne()
            .HasForeignKey(o => o.OrderId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<OrderModel>()
            .OwnsOne(o => o.CustomerInfo);

        modelBuilder.Entity<OrderModel>()
            .OwnsOne(o => o.DeliveryInfo);

        modelBuilder.Entity<OrderItemModel>()
            .HasOne<ProductModel>()
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }

    public static void ConfigureProduct(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductModel>()
            .HasOne<CategoryModel>()
            .WithMany()
            .HasForeignKey(c => c.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ProductModel>()
            .HasMany(p => p.Attributes)
            .WithOne()
            .HasForeignKey(a => a.ProductId);

        modelBuilder.Entity<ProductModel>()
            .Property(p => p.Price)
            .HasColumnType("numeric(18, 2)");
    }

    public static void ConfigureUser(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.Favorites)
            .WithOne()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<UserModel>()
            .HasMany(u => u.ShoppingCart)
            .WithOne()
            .HasForeignKey(f => f.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<ShoppingCartItemModel>()
            .HasOne<ProductModel>()
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<FavoriteItemModel>()
            .HasOne<ProductModel>()
            .WithMany()
            .HasForeignKey(i => i.ProductId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}