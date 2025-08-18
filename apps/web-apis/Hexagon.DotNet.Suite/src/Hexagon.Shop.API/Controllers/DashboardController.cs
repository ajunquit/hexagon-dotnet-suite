using Hexagon.Shop.Application.Dashboard.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hexagon.Shop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DashboardController : ControllerBase
    {
        private readonly ICounterAppService _counterAppService;
        private readonly ICustomerDashboardAppService _customerDashboardAppService;

        public DashboardController(
            ICounterAppService counterAppService,
            ICustomerDashboardAppService customerDashboardAppService)
        {
            _counterAppService = counterAppService;
            _customerDashboardAppService = customerDashboardAppService;
        }

        [HttpGet("counters")]
        public async Task<IActionResult> Counters()
        {
            var result = await _counterAppService.GetCountersAsync();
            return Ok(result);
        }

        [HttpGet("new-clients-by-last-x-months")]
        public async Task<IActionResult> NewClientsByLastMonth([FromQuery] int lastMonths)
        {
            var result = await _customerDashboardAppService.GetNewClientsByLastMonthAsync(lastMonths);
            return Ok(result);
        }
    }
}
