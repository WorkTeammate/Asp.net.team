using DiscountManagement.Domain.CustomerDiscountAgg;
using DiscountManagement.Infrastructure.EFcore.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountManagement.Infrastructure.EFcore.Extentions
{
    public static class DiscountInfrastructureConfiguration
    {
        public static void AddDiscountInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICustomerDiscountRepository, CustomerDiscountRepository>();
            services.AddDbContext<DiscountContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBserver")));

        }
    }
}
