using BlogManagement.Domain.ArticleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EfCore.Mapping
{
    public class ArticleMapping : IEntityTypeConfiguration<Article>
    {
        public void Configure(EntityTypeBuilder<Article> builder)
        {
            builder.ToTable("Article");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Description);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(500);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(500);
            builder.Property(x => x.MetaDescription).IsRequired().HasMaxLength(500);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(500);
            builder.Property(x => x.CanonicalAddress);
            builder.Property(x => x.CategoryId);

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Articles)
                    .HasForeignKey(x => x.CategoryId);
            
        }
    }
}
