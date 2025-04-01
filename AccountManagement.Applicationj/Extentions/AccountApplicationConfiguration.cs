using _01_Framework.Application;
using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.Role;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountManagement.Application.Extentions
{
    public static class AccountApplicationConfiguration
    {
        public static void AddAccountApplicationConfiguration(this IServiceCollection services)
        {
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IRoleApplication, RoleApplication>();

        }
    }
}
