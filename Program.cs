global using Microsoft.AspNetCore.Mvc;
global using Microsoft.EntityFrameworkCore;
using dotnet_ecommerce.Data;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
    {
        // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
        app.UseHsts();
        
    } else {
        app.UseSwagger();
        app.UseSwaggerUI();
    }


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

// using (var scope = app.Services.CreateScope()){
//     var services = scope.ServiceProvider;

//     var context = services.GetRequiredService<DataContext>();
//     context.Database.Migrate();

//     var userManager = services.GetRequiredService<UserManager<IdentityUser>>();
//     var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

//     SeedAdminData.Initialize(context, userManager, roleManager).Wait();
// }

app.Run();
