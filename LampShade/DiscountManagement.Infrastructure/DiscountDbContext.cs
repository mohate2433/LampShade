using DiscountManagement.Domain.ColleagueDiscountAggregate;
using DiscountManagement.Domain.CustomerDiscountAggregate;
using DiscountManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions<DiscountDbContext> options) : base(options)
        {
        }

        public DbSet<CustomerDiscount> CustomerDiscount { get; set; }
        public DbSet<ColleagueDiscount> ColleagueDiscount { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            var assembly = typeof(CustomerDiscountMapper).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
