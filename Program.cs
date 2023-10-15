global using Microsoft.EntityFrameworkCore;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Hosting;


namespace dotnet_ecommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                var db = services.GetRequiredService<DataContext>();
                var userManager = services.GetRequiredService<UserManager<UserStore>>(); 
                var roleManager = services.GetRequiredService<RoleManager<UserRole>>();

                SeedAdminData.Initialize(db, userManager, roleManager).Wait();
            }
            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
