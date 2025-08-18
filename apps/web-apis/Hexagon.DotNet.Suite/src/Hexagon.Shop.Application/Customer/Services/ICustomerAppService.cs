using Hexagon.Shop.Application.Customer.Dtos;

namespace Hexagon.Shop.Application.Customer.Services
{
    public interface ICustomerAppService
    {
        Task<CustomerResponse> AddCustomerAsync(CustomerRequest request);
        Task<IEnumerable<CustomerResponse>> GetAllCustomersAsync();
        Task<CustomerResponse?> GetCustomerByIdAsync(Guid id);
        Task<bool> EditCustomerAsync(Guid id, CustomerRequest request);
        Task<bool> DeleteCustomerAsync(Guid id);
    }
}
