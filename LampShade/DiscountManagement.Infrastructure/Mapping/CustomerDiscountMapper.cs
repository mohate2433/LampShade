using DiscountManagement.Domain.CustomerDiscountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.Mapping
{
    public class CustomerDiscountMapper : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Reason).HasMaxLength(500);
        }
    }
}
