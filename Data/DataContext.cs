using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace dotnet_ecommerce.Data
{
    public class DataContext : IdentityDbContext<Models.UserStore>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>().ToTable("UserRoles");

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

        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<OrderItems> OrderItems {get; set;}
    }
}