using DiscountManagement.Domain.CustomerDiscountAgg;
using Microsoft.EntityFrameworkCore;

namespace DiscountManagement.Infrastructure.EFcore
{
    public class DiscountContext : DbContext
    {
        public DbSet<CustomerDiscount> CustomerDiscount { get; set; }
        public DiscountContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerDiscount).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
