﻿using Market.ShopsManagement.Domain.ProductsAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ShopsManagement.Domain.ProductsAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Mapping
{
    public class ProductsMapping : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasMaxLength(90);
            builder.Property(x => x.ShortDescription).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).HasMaxLength(600);
            builder.Property(x => x.Picture).IsRequired().HasMaxLength(4000);
            builder.Property(x => x.PictureAlt).IsRequired().HasMaxLength(100);
            builder.Property(x => x.PictureTitle).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Slug).IsRequired().HasMaxLength(90);
            builder.Property(x => x.Keywords).HasMaxLength(120);
            builder.Property(x => x.CreationDate).IsRequired();

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Products)
                      .HasForeignKey(x => x.CategoryId);


        }
    }
}
