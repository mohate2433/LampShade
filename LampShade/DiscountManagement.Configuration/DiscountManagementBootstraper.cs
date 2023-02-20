using DiscountManagement.Domain.Contract;
using DiscountManagement.Infrastructure.Services;
using DiscountManagement.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using DiscountManagement.Application.Contract.Contract;
using Microsoft.EntityFrameworkCore;
using DiscountManagement.Application.Services;

namespace DiscountManagement.Configuration
{
    public class DiscountManagementBootstraper
    {
        public static void Configure(IServiceCollection services, string connectionString)
        {
            services.AddTransient<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddTransient<ICustomerDiscountApplication, CustomerDiscountApplication>();
            
            services.AddTransient<IColleagueDiscountRepository, ColleagueDiscountRepository>();
            services.AddTransient<IColleagueDiscountApplication, ColleagueDiscountApplication>();


            services.AddDbContext<DiscountDbContext>(x => x.UseSqlServer(connectionString));
        }
    }
}