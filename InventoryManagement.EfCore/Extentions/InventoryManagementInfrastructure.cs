using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ShopsManagement.Domain.MarketCategoryAgg;
using ShopsManagement.Domain.ProductAgg;
using ShopsManagement.Domain.ShopsAgg;
using ShopsManagement.Infrastructure.EFcore.Repository;
using ShopsManagement.Infrastructure.EFcore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using InventoryManagement.Domain.InventoryAgg;
using InventoryManagement.EfCore.Repository;

namespace InventoryManagement.EfCore.Extentions
{
    public static class InventoryManagementInfrastructure
    {
        public static void AddInventoryInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IInventoryRepository, InventoryRepository>();
            services.AddDbContext<InventoryContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBserver")));

        }
    }
}
