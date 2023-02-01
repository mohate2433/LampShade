using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.DomainModels.ProductAggregate;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(h => h.ID);

            builder.Property(p => p.Name).HasMaxLength(300).IsRequired();
            builder.Property(p => p.Code).HasMaxLength(15).IsRequired();
            builder.Property(p => p.ShortDescription).HasMaxLength(500).IsRequired();
            builder.Property(p => p.Description).HasMaxLength(1000);

            builder.Property(p => p.Picture).HasMaxLength(1000);
            builder.Property(p => p.PictureAlt).HasMaxLength(255);
            builder.Property(p => p.PictureTitle).HasMaxLength(500);

            builder.Property(p => p.Keywords).HasMaxLength(100).IsRequired();
            builder.Property(p => p.MetaDescription).HasMaxLength(150).IsRequired();
            builder.Property(p => p.Slug).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                .HasForeignKey(x => x.CategoryID);
            builder.HasMany(x => x.ProductPictures)
                .WithOne(x => x.Product)
                .HasForeignKey(x => x.ProductID);
        }
    }
}
