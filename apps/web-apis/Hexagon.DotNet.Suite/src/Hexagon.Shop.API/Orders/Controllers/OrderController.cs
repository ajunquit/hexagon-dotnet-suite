using Hexagon.Shop.Application.Order.Dtos;
using Hexagon.Shop.Application.Order.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hexagon.Shop.API.Orders.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderAppService _orderAppService;

        public OrderController(IOrderAppService orderAppService)
        {
            _orderAppService = orderAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AddOrder([FromBody] OrderRequest request)
        {
            var result = await _orderAppService.AddOrderAsync(request);
            return CreatedAtAction(nameof(GetOrderById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOrders()
        {
            var orders = await _orderAppService.GetAllOrdersAsync();
            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderById(Guid id)
        {
            var order = await _orderAppService.GetOrderByIdAsync(id);
            if (order == null)
                return NotFound();
            return Ok(order);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditOrder(Guid id, [FromBody] OrderRequest request)
        {
            var result = await _orderAppService.EditOrderAsync(id, request);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id)
        {
            var result = await _orderAppService.DeleteOrderAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
