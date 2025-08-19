using Hexagon.Shop.Application.Auth.Commands.Register.Dto;
using Microsoft.AspNetCore.Identity;

namespace Hexagon.Shop.Application.Auth.Commands.Register
{
    public class RegisterCommandHandler : IRegisterCommandHandler
    {
        private readonly UserManager<IdentityUser> _userManager;

        public RegisterCommandHandler(
            UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Handle(RegisterRequest request)
        {
            var user = new IdentityUser
            {
                UserName = request.UserName,
                Email = request.Email,
                EmailConfirmed = true
            };
            return await _userManager.CreateAsync(user, request.Password);
        }
    }
}
