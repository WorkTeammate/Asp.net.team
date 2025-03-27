using Microsoft.EntityFrameworkCore;
using ShopsManagement.Domain.ProductAgg;
using ShopsManagement.Domain.ProductCategoryAgg;
using ShopsManagement.Infrastructure.EFcore.Mapping;

namespace ShopsManagement.Infrastructure.EFcore
{
    public class ShopsContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public ShopsContext(DbContextOptions<ShopsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Product).Assembly);
        }
    }
}
