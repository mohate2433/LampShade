﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopManagement.Domain.DomainModels.SlideAggregate;

namespace ShopManagement.Infrastructure.Mapping
{
    public class SlideMapping : IEntityTypeConfiguration<Slide>
    {
        public void Configure(EntityTypeBuilder<Slide> builder)
        {
            builder.ToTable("Slides");
            builder.HasKey(x => x.ID);

            builder.Property(x => x.Picture).HasMaxLength(1000);
            builder.Property(x => x.PictureAlt).HasMaxLength(500).IsRequired();
            builder.Property(x => x.PictureTitle).HasMaxLength(500).IsRequired();
            builder.Property(x => x.Heading).HasMaxLength(255).IsRequired();
            builder.Property(x => x.Title).HasMaxLength(255);
            builder.Property(x => x.BtnText).HasMaxLength(50).IsRequired();
        }
    }
}
