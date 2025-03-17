using BlogManagement.Application.Contracts.ArticleCategory;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogManagement.Application.Extentions
{
    public static class BlogApplicationConfiguration
    {
        public static void AddBlogApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IArticleCategoryApplication, ArticleCategoryApplication>();
        }
    }
}
