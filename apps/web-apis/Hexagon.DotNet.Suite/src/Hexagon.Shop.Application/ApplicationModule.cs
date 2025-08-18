using Hexagon.Shop.Application.Customer.Services;
using Hexagon.Shop.Application.Dashboard.Services;
using Hexagon.Shop.Application.Dashboard.Services.Impl;
using Hexagon.Shop.Application.Order.Services;
using Hexagon.Shop.Application.OrderEntity.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Hexagon.Shop.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddScoped<ICustomerAppService, CustomerAppService>();
            services.AddScoped<IOrderAppService, OrderAppService>();
            services.AddScoped<ICounterAppService, CounterAppService>();
            services.AddScoped<ICustomerDashboardAppService, CustomerDashboardAppService>();
            return services;
        }
    }
}
