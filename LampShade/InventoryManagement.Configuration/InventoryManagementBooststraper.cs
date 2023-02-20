using InventoryManagement.Application.Contracts.Contracts;
using InventoryManagement.Domain.Contracts;
using InventoryManagement.Infrastructure;
using InventoryManagement.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace InventoryManagement.Configuration
{
    public class InventoryManagementBooststraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IInventoryRepository, InventoryRepository>();
            //services.AddTransient<IInventoryApplication, inventoryapplicatio>();


            services.AddDbContext<InventoryDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
