using AccountManagement.Domain.AccountAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMaagement.Infrastructure.EFcore.Mapping
{
    public class AccountMapping : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Fullname).HasMaxLength(70);
            builder.Property(x => x.Username).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ProfilePhoto).HasMaxLength(4000);
            builder.Property(x => x.Mobile).HasMaxLength(12);
            builder.Property(x => x.Password).HasMaxLength(16);

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);



        }
    }
}
