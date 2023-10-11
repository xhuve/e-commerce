using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Identity;

namespace dotnet_ecommerce.Data
{
    public class SeedAdminData
    {
        public static async Task Initialize(DataContext _db,
        UserManager<UserStore> userManager,
        RoleManager<UserRole> roleManager
        )
        {
            _db.Database.EnsureCreated();

            if(await roleManager.FindByNameAsync("Admin") == null){
                Console.WriteLine("Adding Admin Role");
                await roleManager.CreateAsync(new UserRole{role = "Admin", Name = "Admin"});
            }

            if(await roleManager.FindByNameAsync("User") == null){
                await roleManager.CreateAsync(new UserRole{role = "User", Name = "User"});
                Console.WriteLine("Adding User Role");
            }

            if(await userManager.FindByEmailAsync("admin@admin.a") == null){
                var user = new UserStore {
                    user = "adminUser",
                    useremail = "admin@admin.a",
                    UserName = "adminUser", 
                    Email = "admin@admin.a",
                };

                var res = await userManager.CreateAsync(user, "Admin@123123");
                if(res.Succeeded){
                    await userManager.AddToRoleAsync(user, "ADMIN");
                    await userManager.AddPasswordAsync(user, "Admin@123123");
                    Console.WriteLine("Added the user stuff");
                } else {
                    Console.WriteLine("CreateAsync problem");
                }
            }
        }
    }
}