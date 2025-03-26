using InventoryManagement.Application.Contracts.Inventory;
using Microsoft.Extensions.DependencyInjection;
using ShopsManagement.Application.Contracts.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Application.Extentions
{
    public static class InventoryApplicationConfigurations
    {
        public static void AddInventoryManagementApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IInventoryApplicaton, InventoryApplication>();
        }
    }
}
