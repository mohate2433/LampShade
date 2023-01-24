using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Services;
using ShopManagement.Domain.Services.Contracts;
using ShopManagement.Infrastructure;
using ShopManagement.Infrastructure.Repository;
using ShopManement.Application.Contracts.Contracts;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configuration(IServiceCollection services , string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
