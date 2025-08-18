using Hexagon.Shop.Application.Dashboard.Dtos;

namespace Hexagon.Shop.Application.Dashboard.Services
{
    public interface ICustomerDashboardAppService
    {
        Task<ChartPropertiesResponse> GetNewClientsByLastMonthAsync(int lastMonths);
    }
}
