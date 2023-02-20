using InventoryManagement.Domain.InventoryAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InventoryManagement.Infrastructure.Mapping
{
    public class InventoryMapping : IEntityTypeConfiguration<Inventory>
    {
        public void Configure(EntityTypeBuilder<Inventory> builder)
        {
            builder.ToTable("Inventory");
            builder.HasKey(x => x.ID);

            builder.OwnsMany(x => x.Oprations, modelBuilder =>
            {
                modelBuilder.ToTable("OprationInventory");
                modelBuilder.HasKey(x => x.Id);

                modelBuilder.Property(x => x.Description).HasMaxLength(1000);

                modelBuilder.WithOwner(x => x.Inventory).HasForeignKey(x => x.InventotyId);
            });
        }
    }
}
