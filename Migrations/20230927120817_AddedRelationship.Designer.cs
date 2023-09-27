﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dotnet_ecommerce.Data;

#nullable disable

namespace dotnet_ecommerce.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20230927120817_AddedRelationship")]
    partial class AddedRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("dotnet_ecommerce.Models.Order", b =>
                {
                    b.Property<int>("order_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<float>("total_value")
                        .HasColumnType("float");

                    b.Property<int>("user_id")
                        .HasColumnType("int");

                    b.HasKey("order_id");

                    b.HasIndex("user_id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.OrderItems", b =>
                {
                    b.Property<int>("order_items_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("order_id")
                        .HasColumnType("int");

                    b.Property<int>("product_id")
                        .HasColumnType("int");

                    b.Property<int>("quantity")
                        .HasColumnType("int");

                    b.Property<float>("unit_price")
                        .HasColumnType("float");

                    b.HasKey("order_items_id");

                    b.HasIndex("order_id");

                    b.ToTable("OrderList");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.Product", b =>
                {
                    b.Property<int>("product_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("category")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("order_list_id")
                        .HasColumnType("int");

                    b.Property<float>("price")
                        .HasColumnType("float");

                    b.HasKey("product_id");

                    b.HasIndex("order_list_id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.User", b =>
                {
                    b.Property<int>("user_id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("first_name")
                        .HasColumnType("longtext");

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("user_id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.Order", b =>
                {
                    b.HasOne("dotnet_ecommerce.Models.User", "User")
                        .WithMany("orders")
                        .HasForeignKey("user_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.OrderItems", b =>
                {
                    b.HasOne("dotnet_ecommerce.Models.Order", "Order")
                        .WithMany("OrderList")
                        .HasForeignKey("order_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.Product", b =>
                {
                    b.HasOne("dotnet_ecommerce.Models.OrderItems", "OrderList")
                        .WithMany("Products")
                        .HasForeignKey("order_list_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("OrderList");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.Order", b =>
                {
                    b.Navigation("OrderList");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.OrderItems", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("dotnet_ecommerce.Models.User", b =>
                {
                    b.Navigation("orders");
                });
#pragma warning restore 612, 618
        }
    }
}
