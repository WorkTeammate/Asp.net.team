using _0_Framework.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsManagement.Application.Contracts.MarketCategories;
using ShopsManagement.Application.Contracts.Markets;
using ShopsManagement.Configuration.Permissions;
using ShopsManagement.Domain.MarketCategoryAgg;
using ShopsManagement.Domain.ProductAgg;
using ShopsManagement.Domain.ShopsAgg;
using ShopsManagement.Infrastructure.EFcore.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsManagement.Infrastructure.EFcore.Extentions
{
    public static class InfrastructureConfiguration
    {
        public static void AddShopsMangementInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IMarketsRepository, MarketRepository>();
            services.AddScoped<IMarketCategoryRepository, MarketCategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddTransient<IPermissionExposer, ShopPermissionExposer>();

            services.AddDbContext<ShopsContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBserver")));

        }
    }
}
