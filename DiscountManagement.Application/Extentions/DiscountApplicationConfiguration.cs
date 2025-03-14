using DiscountManagement.Application.Contracts.CustomerDiscount;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Application.Extentions
{
    public static class DiscountApplicationConfiguration
    {
        public static void AddDiscountApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<ICustomerDiscountApplication, CustomerDiscountApplication>();
        }
    }
}
