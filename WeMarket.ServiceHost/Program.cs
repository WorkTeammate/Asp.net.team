
using _01_Framework.Application;
using _01_Framework.Infrastructure;
using AccountManagement.Application.Extentions;
using AccountManagement.Infrastructure.EFCore.Extentions;
using BlogManagament.Infrastructure.EFCore.Extentions;
using BlogManagement.Application.Extentions;
using DiscountManagement.Application.Extentions;
using DiscountManagement.Infrastructure.EFcore.Extentions;
using InventoryManagement.Application.Extentions;
using InventoryManagement.EfCore.Extentions;
using Microsoft.AspNetCore.Authentication.Cookies;
using ShopsManagement.Application.Extentions;
using ShopsManagement.Infrastructure.EFcore.Extentions;
using WeMarket.ServiceHost;


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

//Account 
builder.Services.AddAccountInfrastructureDependencies(builder.Configuration);
builder.Services.AddAccountApplicationConfiguration();
//Account 


//Auth 
builder.Services.AddSingleton<IAuthHelper, AuthHelper>();
builder.Services.AddSingleton<IPasswordHasher, PasswordHasher>();
builder.Services.AddSingleton<IFileUploader, FileUploader>();
//Auth 


// sevices inside of Extention

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
          .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, o =>
          {
              o.LoginPath = new PathString("/Account");
              o.LogoutPath = new PathString("/Account");
              o.AccessDeniedPath = new PathString("/AccessDenied");
          });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("AdminArea",
        builder => builder.RequireRole(new List<string> { Roles.Admin }));

    options.AddPolicy("Blog",
        builder => builder.RequireRole(new List<string> { Roles.Admin }));

    options.AddPolicy("Discount",
        builder => builder.RequireRole(new List<string> { Roles.Admin }));

    options.AddPolicy("Account",
        builder => builder.RequireRole(new List<string> { Roles.Admin }));

    options.AddPolicy("Inventory",
    builder => builder.RequireRole(new List<string> { Roles.Admin }));

    options.AddPolicy("Product",
builder => builder.RequireRole(new List<string> { Roles.Admin }));
});

builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
    builder
        .WithOrigins("https://localhost:7270/")
        .AllowAnyHeader()
        .AllowAnyMethod()));


builder.Services.AddRazorPages()
    .AddMvcOptions(options => options.Filters.Add<SecurityPageFilter>())
    .AddRazorPagesOptions(options =>
    {
        options.Conventions.AuthorizeAreaFolder("Admin", "/", "AdminArea");
        options.Conventions.AuthorizeAreaFolder("Admin", "/Blog", "Blog");
        options.Conventions.AuthorizeAreaFolder("Admin", "/Discounts", "Discount");
        options.Conventions.AuthorizeAreaFolder("Admin", "/AccountsManagement", "Account");
        options.Conventions.AuthorizeAreaFolder("Admin", "/InventoryManagement", "Inventory");
        options.Conventions.AuthorizeAreaFolder("Admin", "/ProductsManagement", "Product");
    });
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

app.UseCors("MyPolicy");

app.MapRazorPages();

app.Run();
