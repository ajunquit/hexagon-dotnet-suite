using Auth.Service.Infrastructure.Contexts;
using Hexagon.Shop.Domain.Common.Interfaces;
using Hexagon.Shop.Domain.Customers.Interfaces;
using Hexagon.Shop.Domain.Orders.Interfaces;
using Hexagon.Shop.Infrastructure.Persistence.Contexts;
using Hexagon.Shop.Infrastructure.Persistence.Contexts.App;
using Hexagon.Shop.Infrastructure.Persistence.Contexts.Auth;
using Hexagon.Shop.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagon.Shop.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            RegisterDbContexts(services, configuration);
            RegisterRepositories(services);
            return services;
        }

        private static void RegisterRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWorkAsync, UnitOfWorkAsync>();
            services.AddScoped<ICustomerRepositoryAsync, CustomerRepositoryAsync>();
            services.AddScoped<IOrderRepositoryAsync, OrderRepositoryAsync>();
        }

        private static void RegisterDbContexts(IServiceCollection services, IConfiguration configuration)
        {
            RegisterAppDbContext(services, configuration);
            RegisterAuthDbContext(services, configuration);
        }

        private static void RegisterAuthDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAuthDbContext, AuthDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Local"),
                    sqlOptions =>
                        sqlOptions.MigrationsAssembly(typeof(AuthDbContext).Assembly.FullName)
                )
            );
        }

        private static void RegisterAppDbContext(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAppDbContext, AppDbContext>(options =>
                options.UseSqlServer(
                    configuration.GetConnectionString("Local"),
                    sqlOptions =>
                        sqlOptions.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)
                )
            );
        }
    }
}
