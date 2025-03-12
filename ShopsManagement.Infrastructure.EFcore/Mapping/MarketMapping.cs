using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsManagement.Domain.ShopsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Mapping
{
    public class MarketMapping : IEntityTypeConfiguration<Markets>
    {
        public void Configure(EntityTypeBuilder<Markets> builder)
        {
            builder.ToTable("Markets");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x=>x.PersianName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.EnglishName).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Description).HasMaxLength(1000);
            builder.Property(x=>x.ShortDescription).IsRequired().HasMaxLength(100);
            builder.Property(x=>x.Picture).IsRequired().HasMaxLength(4000);
            builder.Property(x=>x.PictureTitle).IsRequired().HasMaxLength(150);
            builder.Property(x=>x.PictureAlt).IsRequired().HasMaxLength(150);
            builder.Property(x=>x.Slug).HasMaxLength(70).IsRequired();
            builder.Property(x=>x.CategoryId).IsRequired();

            builder.HasOne(x => x.MarketCategory)
                .WithMany(x => x.Markets)
                  .HasForeignKey(x => x.CategoryId);

            builder.HasMany(x => x.Products)
                .WithOne(x => x.Markets)
                    .HasForeignKey(x => x.MarketId);
        }
    }
}
