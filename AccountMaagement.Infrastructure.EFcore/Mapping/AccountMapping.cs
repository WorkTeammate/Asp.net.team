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

            builder.Property(x => x.FullName).HasMaxLength(70);
            builder.Property(x => x.UserName).HasMaxLength(50).IsRequired();
            builder.Property(x => x.ProfilePicture).HasMaxLength(4000);
            builder.Property(x => x.MobileNumber).HasMaxLength(12);
            builder.Property(x => x.Password).HasMaxLength(16);
            builder.Property(x => x.Gmail).HasMaxLength(100);

            builder.HasOne(x => x.Role).WithMany(x => x.Accounts).HasForeignKey(x => x.RoleId);


        }
    }
}
