using Hexagon.Shop.Domain.Customers.Interfaces;
using Hexagon.Shop.Domain.Orders.Interfaces;

namespace Hexagon.Shop.Domain.Common.Interfaces
{
    public interface IUnitOfWorkAsync
    {
        ICustomerRepositoryAsync CustomerRepository { get; }
        IOrderRepositoryAsync OrderRepository { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
