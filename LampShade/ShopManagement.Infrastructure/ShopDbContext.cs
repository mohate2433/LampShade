using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.DomainModels.ProductAggregate;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;
using ShopManagement.Domain.DomainModels.SlideAggregate;
using ShopManagement.Infrastructure.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Infrastructure
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext(DbContextOptions<ShopDbContext> options) : base(options)
        {
        }

        public DbSet<ProductCategory>? ProductCategories { get; set; }
        public DbSet<Product>? Products { get; set; }
        public DbSet<ProductPicture>? ProductPictures { get; set; }
        public DbSet<Slide>? Slides { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var assembly = typeof(ProductCategoryMapping).Assembly;
            modelBuilder.ApplyConfigurationsFromAssembly(assembly);

            
            base.OnModelCreating(modelBuilder);
        }
    }
}
