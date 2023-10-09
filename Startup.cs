using dotnet_ecommerce.Data;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotnet_ecommerce
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSwaggerGen();
            services.AddDbContext<DataContext>(options => 
            {
                options.UseMySQL("server=localhost;database=ecommerce;user=root;password=shadow!;");
            });
            services.AddIdentity<UserStore, UserRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddUserManager<UserManager<UserStore>>()
                .AddRoleManager<RoleManager<UserRole>>()
                .AddDefaultTokenProviders();
            services.AddAuthorization();
            // Add your services, database contexts, authentication, and more here.
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            else
            {
                // Configure error handling for production.
                // e.g., app.UseExceptionHandler("/Home/Error");
                //      app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Add additional endpoints as needed.
            });
        }
    }
}
