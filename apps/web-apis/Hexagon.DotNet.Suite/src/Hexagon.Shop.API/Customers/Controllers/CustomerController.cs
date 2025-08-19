using Hexagon.Shop.Application.Customer.Dtos;
using Hexagon.Shop.Application.Customer.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Hexagon.Shop.API.Customers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerAppService _customerAppService;

        public CustomerController(ICustomerAppService customerAppService)
        {
            _customerAppService = customerAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AddCustomer([FromBody] CustomerRequest request)
        {
            var result = await _customerAppService.AddCustomerAsync(request);
            return CreatedAtAction(nameof(GetCustomerById), new { id = result.Id }, result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerAppService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerById(Guid id)
        {
            var customer = await _customerAppService.GetCustomerByIdAsync(id);
            if (customer == null)
                return NotFound();
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditCustomer(Guid id, [FromBody] CustomerRequest request)
        {
            var result = await _customerAppService.EditCustomerAsync(id, request);
            if (!result)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(Guid id)
        {
            var result = await _customerAppService.DeleteCustomerAsync(id);
            if (!result)
                return NotFound();
            return NoContent();
        }
    }
}
