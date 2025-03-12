using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsManagement.Domain.MarketCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Mapping
{
    public class MarketCategoryMapping : IEntityTypeConfiguration<MarketCategory>
    {
        public void Configure(EntityTypeBuilder<MarketCategory> builder)
        {
            builder.ToTable("MarketCategories");
            builder.HasKey(x=>x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(600);
            builder.Property(x => x.Picture).HasMaxLength(4000);
            builder.Property(x => x.PictureAlt).HasMaxLength(80);
            builder.Property(x => x.PictureTitle).HasMaxLength(80);
            builder.Property(x => x.KeyWords).HasMaxLength(400).IsRequired();
            builder.Property(x => x.MetaDescription).HasMaxLength(400).IsRequired();
            builder.Property(x => x.Slug).HasMaxLength(100).IsRequired();

            builder.HasMany(x => x.Markets).WithOne(x => x.MarketCategory).HasForeignKey(x => x.CategoryId);

        }
    }
}
