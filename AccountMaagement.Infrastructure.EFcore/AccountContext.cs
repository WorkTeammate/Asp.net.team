using AccountMaagement.Infrastructure.EFcore.Mapping;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;

namespace AccountMaagement.Infrastructure.EFcore
{
    public class AccountContext : DbContext
    {
        public DbSet<Account> Account { get; set; }
        public DbSet<Role> Role { get; set; }
        public AccountContext(DbContextOptions<AccountContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Role).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
