﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.DomainModels.ProductCategoryAggregates;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategories");
            builder.HasKey(h => h.ID);

            builder.Property(p => p.Name).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Descripion).HasMaxLength(500);
            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.PictureAlt).HasMaxLength(255);
            builder.Property(p => p.PictureTitle).HasMaxLength(500);

            builder.Property(p => p.Keywords).HasMaxLength(80).IsRequired();
            builder.Property(p => p.MetaDescripion).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(300).IsRequired();

            builder.HasMany(x => x.Products).WithOne(x => x.Category).HasForeignKey(x => x.CategoryID);
        }
    }
}
