using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace dotnet_ecommerce.Data
{
    public class SeedAdminData
    {
        public static async Task Initialize(DataContext _db,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager
        )
        {

            _db.Database.EnsureCreated();

            if(await roleManager.FindByNameAsync("Admin") == null){
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if(await roleManager.FindByNameAsync("User") == null){
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

            if(await userManager.FindByEmailAsync("admin@admin.a") == null){
                var user = new IdentityUser {
                    UserName = "adminUser",
                    Email = "admin@admin.a",
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