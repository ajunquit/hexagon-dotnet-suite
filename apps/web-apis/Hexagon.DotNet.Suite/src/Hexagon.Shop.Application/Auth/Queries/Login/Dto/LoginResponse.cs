namespace Hexagon.Shop.Application.Auth.Queries.Login.Dto
{
    public class LoginResponse()
    {
        public Guid Id { get; set; } = Guid.Empty;
        public string Email { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Token { get; set; } = string.Empty;
    }
}
