using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.DomainModels.ProductPictureAggregates;

namespace ShopManagement.Infrastructure.Mapping
{
    public class ProductPictureMapping : IEntityTypeConfiguration<ProductPicture>
    {
        public void Configure(EntityTypeBuilder<ProductPicture> builder)
        {
            builder.ToTable("ProductPictures");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x=>x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x=>x.PictureTitle).HasMaxLength(500).IsRequired();

            builder.HasOne(x => x.Product)
                .WithMany(x => x.ProductPictures)
                .HasForeignKey(x => x.ProductID);
        }
    }
}
