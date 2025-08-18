using Hexagon.Shop.Domain.Customers.Entity;
using Hexagon.Shop.Domain.Orders.Entity;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Shop.Infrastructure.Persistence.Contexts
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
    }
}
