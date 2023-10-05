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
                await roleManager.CreateAsync(new UserRole{role = "Admin"});
            }

            if(await roleManager.FindByNameAsync("User") == null){
                await roleManager.CreateAsync(new UserRole{role = "User"});
            }

            if(await userManager.FindByEmailAsync("admin@admin.a") == null){
                var user = new UserStore {
                    username = "adminUser",
                    email = "admin@admin.a",
                };

                var res = await userManager.CreateAsync(user, "admin123admin");
                if(res.Succeeded){
                    await userManager.AddPasswordAsync(user, "admin123admin");
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}