using DiscountManagement.Domain.ColleagueDiscountAggregate;
using DiscountManagement.Domain.CustomerDiscountAggregate;
using DiscountManagement.Infrastructure.Mapping;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure
{
    public class DiscountDbContext : DbContext
    {
        public DiscountDbContext(DbContextOptions options) : base(options)
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
