namespace Hexagon.Shop.Application.Customer.Dtos
{
    public class CustomerRequest
    {
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Phone { get; set; }
        public string? Address { get; set; }
        public required string RUC { get; set; }
    }
}
