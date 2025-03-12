
using InventoryManagement.Application.Extentions;
using InventoryManagement.EfCore.Extentions;
using ShopsManagement.Application.Extentions;
using ShopsManagement.Infrastructure.EFcore.Extentions;

var builder = WebApplication.CreateBuilder(args);
// sevices inside of Extention
//Shops 
builder.Services.AddShopsMangementApplicationDependencies();
builder.Services.AddShopsMangementInfrastructureDependencies(builder.Configuration);
//Shops 

//Inventory 
builder.Services.AddInventoryInfrastructureDependencies(builder.Configuration);
builder.Services.AddInventoryManagementApplicationDependencies();
//Inventory 

// sevices inside of Extention

// Add services to the container.
builder.Services.AddRazorPages();



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

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
