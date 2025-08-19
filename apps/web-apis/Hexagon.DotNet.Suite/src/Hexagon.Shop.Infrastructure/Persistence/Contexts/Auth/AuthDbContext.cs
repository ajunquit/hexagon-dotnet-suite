using Hexagon.Shop.Infrastructure.Contexts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Shop.Infrastructure.Persistence.Contexts.Auth
{
    public class AuthDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>, IAuthDbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {

        }
    }
}
