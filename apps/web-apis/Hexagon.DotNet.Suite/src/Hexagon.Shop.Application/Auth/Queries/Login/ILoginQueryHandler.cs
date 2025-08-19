using Hexagon.Shop.Application.Auth.Queries.Login.Dto;

namespace Hexagon.Shop.Application.Auth.Queries.Login
{
    public interface ILoginQueryHandler
    {
        Task<LoginResponse> Handle(LoginRequest request);
    }
}
