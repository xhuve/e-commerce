using System.Text;
using System.Text.Json;
using dotnet_ecommerce.Data;
using dotnet_ecommerce.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

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
            services.AddControllers()
                .AddJsonOptions(options =>
                {
                    options.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                    options.JsonSerializerOptions.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;
                });
            
            services.AddSwaggerGen();
            
            services.AddDbContext<DataContext>(options => 
            {
                options.UseMySQL(Configuration["ConnectionStrings:DefaultConnectionString"]);
            });

            services.Configure<IdentityOptions>(options => {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 4;
                options.Password.RequireNonAlphanumeric = false;
            });

            services.AddIdentity<UserStore, UserRole>()
                .AddEntityFrameworkStores<DataContext>()
                .AddSignInManager<SignInManager<UserStore>>()
                .AddUserManager<UserManager<UserStore>>()
                .AddRoles<UserRole>()
                .AddRoleManager<RoleManager<UserRole>>()
                .AddDefaultTokenProviders();
            
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(o => o.LoginPath = "/account/login")
                .AddJwtBearer(x => 
                {
                    x.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidIssuer = Configuration["JwtSettings:Issuer"],
                        ValidAudience = Configuration["JwtSettings:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JwtSettings:Key"])),
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true
                    };
                }
                );
        
            services.AddAuthorization(options => {
                options.AddPolicy("RequireAdminRole", policy =>
                policy.RequireRole("Admin"));
                options.AddPolicy("UserOnly", policy =>
                policy.RequireRole("User"));
            });
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

            app.UseAuthentication();
            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                // Add additional endpoints as needed.
            });
        }
    }
}
