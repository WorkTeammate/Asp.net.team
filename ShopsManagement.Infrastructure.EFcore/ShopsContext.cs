using Microsoft.EntityFrameworkCore;
using ShopsManagement.Domain.MarketCategoryAgg;
using ShopsManagement.Domain.ProductAgg;
using ShopsManagement.Domain.ShopsAgg;
using ShopsManagement.Infrastructure.EFcore.Mapping;

namespace ShopsManagement.Infrastructure.EFcore
{
    public class ShopsContext : DbContext
    {
        public DbSet<MarketCategory> MarketCategories { get; set; }
        public DbSet<Markets> Markets { get; set; }
        public DbSet<Product> Products { get; set; }

        public ShopsContext(DbContextOptions<ShopsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MarketMapping).Assembly);
        }
    }
}
