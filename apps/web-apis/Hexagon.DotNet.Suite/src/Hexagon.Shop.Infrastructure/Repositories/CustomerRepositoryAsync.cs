using Hexagon.Shop.Domain.Customers.Entity;
using Hexagon.Shop.Domain.Customers.Interfaces;
using Hexagon.Shop.Infrastructure.Persistence.Contexts;

namespace Hexagon.Shop.Infrastructure.Repositories
{
    public class CustomerRepositoryAsync(AppDbContext dbContext) : RepositoryAsync<Customer>(dbContext), ICustomerRepositoryAsync
    {
    }
}
