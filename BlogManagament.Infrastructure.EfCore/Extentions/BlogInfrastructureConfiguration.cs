using BlogManagament.Infrastructure.EfCore.Repository;
using BlogManagament.Infrastructure.EFCore.Repository;
using BlogManagement.Domain.ArticleAgg;
using BlogManagement.Domain.ArticleCategoryAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagament.Infrastructure.EFCore.Extentions
{
    public static class BlogInfrastructureConfiguration
    {
        public static void AddBlogInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IArticleCategoryRepository, ArticleCategoryRepository>();
            services.AddScoped<IArticleRepository, ArticleRepository>();
            services.AddDbContext<BlogContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBserver")));

        }
    }
}
