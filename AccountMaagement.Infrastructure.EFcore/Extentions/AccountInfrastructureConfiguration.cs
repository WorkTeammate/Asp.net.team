using AccountMaagement.Infrastructure.EFcore.Repository;
using AccountManagement.Domain.AccountAgg;
using AccountManagement.Domain.RoleAgg;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountMaagement.Infrastructure.EFcore.Extentions
{
    public static class AccountInfrastructureConfiguration
    {
        public static void AddAccountInfrastructureDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAccountRepository, AccountRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddDbContext<AccountContext>(x => x.UseSqlServer(configuration.GetConnectionString("DBserver")));

        }
    }
}
