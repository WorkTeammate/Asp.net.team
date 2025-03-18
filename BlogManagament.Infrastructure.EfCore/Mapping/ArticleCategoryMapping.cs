using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EFCore.Mapping
{
    public class ArticleCategoryMapping : IEntityTypeConfiguration<ArticleCategory>
    {
        public void Configure(EntityTypeBuilder<ArticleCategory> builder)
        {
            builder.ToTable("ArticleCategory");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Picture).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.ShortDescription);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(70);
            builder.Property(x => x.KeyWords).IsRequired();
            builder.Property(x => x.MetaDescription);
            builder.Property(x => x.ShowOrder).IsRequired();


            builder.HasMany(x=>x.Articles)
                .WithOne(x=>x.Category)
                    .HasForeignKey(x=>x.CategoryId);
        }
    }
}
