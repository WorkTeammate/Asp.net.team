using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFcore.Mapping
{
    public class CustomerDiscountMapping : IEntityTypeConfiguration<CustomerDiscount>
    {
        public void Configure(EntityTypeBuilder<CustomerDiscount> builder)
        {
            builder.ToTable("CustomerDiscount");
            builder.HasKey(x => x.Id);

            builder.Property(x=>x.ProductId).IsRequired();
            builder.Property(x=>x.MarketId).IsRequired();
            builder.Property(x=>x.Reason).HasMaxLength(500);
            builder.Property(x=>x.StartDate).IsRequired();
            builder.Property(x=>x.EndDate).IsRequired();
            builder.Property(x=>x.CreationDate).IsRequired();
        }
    }
}
