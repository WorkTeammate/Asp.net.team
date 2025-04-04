using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Mapping
{
    public class ProductCategoryMapping : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("ProductCategory");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.Products).HasMaxLength(4000);
            builder.Property(x=>x.PictureAlt).HasMaxLength(500);
            builder.Property(x=>x.PictureTitle).HasMaxLength(500);
            builder.Property(x=>x.Name).IsRequired().HasMaxLength(500);
            builder.Property(x=>x.MetaDescription).HasMaxLength(500);
            builder.Property(x => x.ShortDescription).HasMaxLength(500);
            builder.Property(x => x.KeyWords).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);

            builder.HasMany(x => x.Products)
              .WithOne(x => x.Category)
                  .HasForeignKey(x => x.CategoryId);

        }
    }
}
