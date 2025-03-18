using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EFCore
{
    public class BlogContext : DbContext
    {
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Article> Article { get; private set; }
        public BlogContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ArticleCategory).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
