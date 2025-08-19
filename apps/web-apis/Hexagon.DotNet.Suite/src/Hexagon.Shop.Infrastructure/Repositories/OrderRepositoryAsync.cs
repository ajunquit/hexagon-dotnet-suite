using Hexagon.Shop.Domain.Orders.Entity;
using Hexagon.Shop.Domain.Orders.Interfaces;
using Hexagon.Shop.Infrastructure.Persistence.Contexts.App;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Shop.Infrastructure.Repositories
{
    public class OrderRepositoryAsync(AppDbContext dbContext) : RepositoryAsync<Order>(dbContext), IOrderRepositoryAsync
    {
        private readonly AppDbContext _dbContext = dbContext;

        public async Task<IEnumerable<Order>> GetAllAsync()
        {
            return await _dbContext.Orders
                .Include(x => x.Customer)
                .Where(x => x.IsActive == Domain.Common.Enums.EnumActiveRecord.Yes)
                .ToListAsync();
        }
    }
}
