using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ecommerce.Data
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseMySQL("server=localhost;database=Ecommerce;user=root;password=shadow!;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
            .HasOne(x => x.User)
            .WithMany(x => x.Orders)
            .HasForeignKey(x => x.user_id);
            
            modelBuilder.Entity<OrderItems>()
            .HasOne(x => x.Order)
            .WithMany(x => x.OrderList)
            .HasForeignKey(x => x.order_id);

            modelBuilder.Entity<OrderItems>()
            .HasMany(x => x.Products)
            .WithOne(x => x.OrderList);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<OrderItems> OrderItems {get; set;}
    }
}