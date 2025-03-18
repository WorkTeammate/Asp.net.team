using _0_Framework.Application;
using _0_Framework.Infrastructure;
using BlogManagament.Infrastructure.EFCore.Extentions;
using BlogManagement.Application.Extentions;
using DiscountManagement.Application.Extentions;
using DiscountManagement.Infrastructure.EFcore.Extentions;
using InventoryManagement.Application.Extentions;
using InventoryManagement.EfCore.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopsManagement.Application.Extentions;
using ShopsManagement.Infrastructure.EFcore.Extentions;
using SM.LampShade;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddHttpContextAccessor();

// sevices inside of Extention
//Shops 
builder.Services.AddShopsMangementApplicationDependencies();
builder.Services.AddShopsMangementInfrastructureDependencies(builder.Configuration);
//Shops 

//Inventory 
builder.Services.AddInventoryInfrastructureDependencies(builder.Configuration);
builder.Services.AddInventoryManagementApplicationDependencies();
//Inventory 

//Discount 
builder.Services.AddDiscountInfrastructureDependencies(builder.Configuration);
builder.Services.AddDiscountApplicationDependencies();
//Discount 

//BlogManagement 
builder.Services.AddBlogApplicationConfiguration();
builder.Services.AddBlogInfrastructureDependencies(builder.Configuration);
//BlogManagement 


//Auth 
builder.Services.AddTransient<IAuthHelper, AuthHelper>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
//Auth 


// sevices inside of Extention

// Add services to the container.
builder.Services.AddRazorPages();

//,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,,



var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAuthentication();

app.UseRouting();
app.UseCookiePolicy();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
