using Hexagon.Shop.Application.Auth.Commands.Register;
using Hexagon.Shop.Application.Auth.Commands.Register.Dto;
using Hexagon.Shop.Application.Auth.Queries.Login;
using Hexagon.Shop.Application.Auth.Queries.Login.Dto;
using Microsoft.AspNetCore.Mvc;

namespace Hexagon.Shop.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginQueryHandler _loginQueryHandler;
        private readonly IRegisterCommandHandler _registerCommandHandler;
        

        public AuthController(
            ILoginQueryHandler loginQueryHandler,
            IRegisterCommandHandler registerCommandHandler)
        {
            _loginQueryHandler = loginQueryHandler;
            _registerCommandHandler = registerCommandHandler;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request)
        {
            var result = await _registerCommandHandler.Handle(request);

            if (result.Succeeded)
                return Ok();
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var result = await _loginQueryHandler.Handle(request);
            if (result != null)
                return Ok(result);

            return Unauthorized();
        }
    }
}
