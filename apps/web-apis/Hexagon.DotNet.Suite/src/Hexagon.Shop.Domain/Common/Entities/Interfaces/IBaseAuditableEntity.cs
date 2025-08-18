using Hexagon.Shop.Domain.Common.Enums;

namespace Hexagon.Shop.Domain.Common.Entities.Interfaces
{
    public interface IBaseAuditableEntity
    {
        EnumActiveRecord IsActive { get; set; }
        string CreatedBy { get; set; }
        string? UpdatedBy { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime? UpdatedDate { get; set; }
    }
}
