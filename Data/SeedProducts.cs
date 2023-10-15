using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Models;

namespace dotnet_ecommerce.Data
{
    public class SeedProducts
    {
        public static void Populate(DataContext _db) {
            _db.Database.EnsureCreated();
            
            List<Product> products = new List<Product>() {
                new Product { name = "Laptop", price = 999.99f, category = "Technology" },
                new Product { name = "Smartphone", price = 599.99f, category = "Technology" },
                new Product { name = "Tablet", price = 299.99f, category = "Technology" },
                new Product { name = "Headphones", price = 49.99f, category = "Technology" },
                new Product { name = "Gaming Console", price = 399.99f, category = "Technology" },
                new Product { name = "Electric Guitar", price = 499.99f, category = "Musical" },
                new Product { name = "Drum Set", price = 299.99f, category = "Musical" },
                new Product { name = "Keyboard", price = 199.99f, category = "Musical" },
                new Product { name = "Microphone", price = 79.99f, category = "Musical" },
                new Product { name = "Acoustic Guitar", price = 349.99f, category = "Musical" }
            };

            _db.Products.AddRange(products);
            _db.SaveChanges();
        }
    }
}