using Hexagon.Shop.Domain.Common.Entities.Interfaces;
using Hexagon.Shop.Domain.Common.Enums;

namespace Hexagon.Shop.Domain.Common.Entities
{
    public class BaseAuditableEntity : IBaseAuditableEntity
    {
        public EnumActiveRecord IsActive { get ; set  ; }
        public required string CreatedBy { get ; set ; }
        public string? UpdatedBy { get ; set ; }
        public DateTime CreatedDate { get; set ; }
        public DateTime? UpdatedDate { get ; set ; }
    }
}
