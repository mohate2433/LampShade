using DiscountManagement.Configuration;
using InventoryManagement.Configuration;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("lampShade");
ShopManagementBootstraper.Configure(builder.Services, connectionString);
DiscountManagementBootstraper.Configure(builder.Services, connectionString);
InventoryManagementBooststraper.Configure(builder.Services, connectionString);
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
