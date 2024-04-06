﻿// <auto-generated />
using System;
using EShop.Application.Storage.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace EShop.Application.Storage.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.AttributeModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("CategoryAttributes");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.AttributeValueModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("AttributeId")
                        .HasColumnType("bigint");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("AttributeId");

                    b.ToTable("AttributeValues");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.CategoryModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Order.OrderItemModel", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("ProductId", "OrderId");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Order.OrderModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationTime")
                        .HasColumnType("timestamp with time zone");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("boolean");

                    b.Property<bool?>("IsSucceeded")
                        .HasColumnType("boolean");

                    b.Property<string>("Message")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("numeric(18, 2)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Product.AttributeModel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductAttributes");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Product.ProductModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<string>("PhotoUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric(18, 2)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.FavoriteItemModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserFavorites");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.ShoppingCartItemModel", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("ProductId")
                        .HasColumnType("uuid");

                    b.Property<int>("Count")
                        .HasColumnType("integer");

                    b.HasKey("UserId", "ProductId");

                    b.HasIndex("ProductId");

                    b.ToTable("UserShoppingCart");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.UserModel", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.AttributeModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Category.CategoryModel", null)
                        .WithMany("Attributes")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.AttributeValueModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Category.AttributeModel", null)
                        .WithMany("Values")
                        .HasForeignKey("AttributeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Order.OrderItemModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Order.OrderModel", null)
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("EShop.Application.Storage.Models.Product.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Order.OrderModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.User.UserModel", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.OwnsOne("EShop.Application.Storage.Models.Order.CustomerModel", "CustomerInfo", b1 =>
                        {
                            b1.Property<Guid>("OrderModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Email")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.Property<string>("PhoneNumber")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("character varying(100)");

                            b1.HasKey("OrderModelId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderModelId");
                        });

                    b.OwnsOne("EShop.Application.Storage.Models.Order.DeliveryModel", "DeliveryInfo", b1 =>
                        {
                            b1.Property<Guid>("OrderModelId")
                                .HasColumnType("uuid");

                            b1.Property<string>("Apartment")
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)");

                            b1.Property<string>("Building")
                                .IsRequired()
                                .HasMaxLength(10)
                                .HasColumnType("character varying(10)");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasMaxLength(400)
                                .HasColumnType("character varying(400)");

                            b1.Property<string>("Comment")
                                .HasMaxLength(400)
                                .HasColumnType("character varying(400)");

                            b1.Property<int?>("Flat")
                                .HasColumnType("integer");

                            b1.Property<string>("Region")
                                .IsRequired()
                                .HasMaxLength(400)
                                .HasColumnType("character varying(400)");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasMaxLength(400)
                                .HasColumnType("character varying(400)");

                            b1.HasKey("OrderModelId");

                            b1.ToTable("Orders");

                            b1.WithOwner()
                                .HasForeignKey("OrderModelId");
                        });

                    b.Navigation("CustomerInfo")
                        .IsRequired();

                    b.Navigation("DeliveryInfo")
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Product.AttributeModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Product.ProductModel", null)
                        .WithMany("Attributes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Product.ProductModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Category.CategoryModel", null)
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.FavoriteItemModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Product.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Application.Storage.Models.User.UserModel", null)
                        .WithMany("Favorites")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.ShoppingCartItemModel", b =>
                {
                    b.HasOne("EShop.Application.Storage.Models.Product.ProductModel", null)
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("EShop.Application.Storage.Models.User.UserModel", null)
                        .WithMany("ShoppingCart")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.AttributeModel", b =>
                {
                    b.Navigation("Values");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Category.CategoryModel", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Order.OrderModel", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.Product.ProductModel", b =>
                {
                    b.Navigation("Attributes");
                });

            modelBuilder.Entity("EShop.Application.Storage.Models.User.UserModel", b =>
                {
                    b.Navigation("Favorites");

                    b.Navigation("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}
