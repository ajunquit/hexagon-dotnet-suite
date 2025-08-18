using Hexagon.Shop.Domain.Common.Entities;
using Hexagon.Shop.Domain.Common.Entities.Interfaces;

namespace Hexagon.Shop.Domain.Customers.Entity
{
    public class Customer : BaseAuditableEntity, IBaseEntity
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public required string RUC { get; set; }
    }
}
