using Hexagon.Shop.Domain.Common.Interfaces;
using Hexagon.Shop.Domain.Customers.Interfaces;
using Hexagon.Shop.Domain.Orders.Interfaces;
using Hexagon.Shop.Infrastructure.Persistence.Contexts;

namespace Hexagon.Shop.Infrastructure.Repositories
{
    public class UnitOfWorkAsync(
        ICustomerRepositoryAsync customerRepository,
        IOrderRepositoryAsync orderRepository,
        AppDbContext dbContext) : IUnitOfWorkAsync, IDisposable
    {
        private readonly AppDbContext _dbContext = dbContext;

        public ICustomerRepositoryAsync CustomerRepository { get; } = customerRepository;

        public IOrderRepositoryAsync OrderRepository { get; } = orderRepository;

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _dbContext?.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
