namespace Hexagon.Shop.Application.Dashboard.Dtos
{
    public class CounterResponse
    {
        public int TotalClients { get; set; }
        public int TotalOrders { get; set; }
        public int CompletedOrders { get; set; }
        public int PendingOrders { get; set; }
    }
}
