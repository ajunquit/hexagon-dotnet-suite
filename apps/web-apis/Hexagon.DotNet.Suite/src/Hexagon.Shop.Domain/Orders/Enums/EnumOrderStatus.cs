namespace Hexagon.Shop.Domain.Orders.Enums
{
    public enum EnumOrderStatus
    {
        Pending = 1,
        Completed = 2,
        Cancelled = 3
    }
    //public static string GetDescription(OrderStatus status)
    //{
    //    return status switch
    //    {
    //        OrderStatus.Pending => "Order is pending",
    //        OrderStatus.Completed => "Order has been delivered",
    //        OrderStatus.Cancelled => "Order has been cancelled",
    //        _ => "Unknown status"
    //    };
    //}
}
