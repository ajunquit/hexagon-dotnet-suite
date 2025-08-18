using Hexagon.Shop.Application.Dashboard.Dtos;

namespace Hexagon.Shop.Application.Dashboard.Services
{
    public interface ICounterAppService
    {
        Task<CounterResponse> GetCountersAsync();
    }
}
