using _01_LampShadeQuery.Contract;
using _01_LampShadeQuery.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ShopManagement.Application.Services;
using ShopManagement.Domain.Contracts;
using ShopManagement.Domain.Services.Contracts;
using ShopManagement.Infrastructure;
using ShopManagement.Infrastructure.Repository;
using ShopManement.Application.Contracts.Contracts;

namespace ShopManagement.Configuration
{
    public class ShopManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<IProductCategoryApplication, ProductCategoryApplication>();
            services.AddTransient<IProductCategoryRepository, ProductCategoryRepository>();

            services.AddTransient<IProductApplication, ProductApplication>();
            services.AddTransient<IProductRepository, ProductRepository>();

            services.AddTransient<IProductPictureApplication, ProductPictureApplication>();
            services.AddTransient<IProductPictureRepository, ProductPictureRepository>();

            services.AddTransient<ISlideApplication, SlideApplication>();
            services.AddTransient<ISlideRepository, SlideRepository>();

            services.AddTransient<ISlideQuery, SlideQuey>();
            services.AddTransient<IProductCategoryQuery, ProductCategoryQuery   >();


            services.AddDbContext<ShopDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}
