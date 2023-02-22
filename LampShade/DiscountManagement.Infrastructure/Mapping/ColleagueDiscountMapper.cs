using DiscountManagement.Domain.ColleagueDiscountAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DiscountManagement.Infrastructure.Mapping
{
    public class ColleagueDiscountMapper : IEntityTypeConfiguration<ColleagueDiscount>
    {
        public void Configure(EntityTypeBuilder<ColleagueDiscount> builder)
        {
            builder.ToTable("ColleagueDiscount");
            builder.HasKey(x => x.ID);
        }
    }
}
