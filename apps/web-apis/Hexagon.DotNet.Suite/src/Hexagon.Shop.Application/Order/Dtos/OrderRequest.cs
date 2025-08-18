namespace Hexagon.Shop.Application.Order.Dtos
{
    public class OrderRequest
    {
        public Guid Id { get; set; }
        public required string OrderNumber { get; set; }
        public required Guid CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public required DateTime OrderDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public required decimal TotalAmount { get; set; }
        public required string Status { get; set; }
        public string? Notes { get; set; }
    }
}
