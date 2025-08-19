using Hexagon.Shop.Application.Auth.Commands.Register.Dto;
using Microsoft.AspNetCore.Identity;

namespace Hexagon.Shop.Application.Auth.Commands.Register
{
    public interface IRegisterCommandHandler
    {
        Task<IdentityResult> Handle(RegisterRequest request);
    }
}
