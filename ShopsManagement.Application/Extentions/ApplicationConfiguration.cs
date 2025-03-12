using Microsoft.Extensions.DependencyInjection;
using ShopsManagement.Application.Contracts.MarketCategories;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Application.Extentions
{
    public static class ApplicationConfiguration
    {
        public static void AddShopsMangementApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMarketApplication, MarketApplication>();
            services.AddScoped<IMarketCategoryApplication, MarketCategoryApplication>();
            services.AddScoped<IProductApplication, ProductApplication>();
        }
    }
}
