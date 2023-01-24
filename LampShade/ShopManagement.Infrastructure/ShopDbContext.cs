using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure
{
    public class ShopDbContext : DbContext
    {
        public DbSet<ProductCategory>? ProductCategories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategory).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
