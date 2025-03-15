using AccountManagement.Application.Contracts.Account;
using AccountManagement.Application.Contracts.role;
using Microsoft.Extensions.DependencyInjection;

namespace AccountManagement.Application.Extentions
{
    public static class AccountApplicationConfiguration
    {
        public static void AddAccountApplicationDependencies(this IServiceCollection services)
        {
            services.AddScoped<IAccountApplication, AccountApplication>();
            services.AddScoped<IRoleApplication, RoleApplication>();
        }
    }
}
