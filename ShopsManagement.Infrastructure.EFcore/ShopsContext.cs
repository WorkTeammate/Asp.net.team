using Market.ShopsManagement.Domain.ProductsAgg;
using Microsoft.EntityFrameworkCore;
using ShopsManagement.Domain.ProductCategoryAgg;
using ShopsManagement.Domain.ProductsAgg;
using ShopsManagement.Infrastructure.EFcore.Mapping;

namespace ShopsManagement.Infrastructure.EFcore
{
    public class ShopsContext : DbContext
    {
        public DbSet<Products> Products { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }

        public ShopsContext(DbContextOptions<ShopsContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Products).Assembly);
        }
    }
}
