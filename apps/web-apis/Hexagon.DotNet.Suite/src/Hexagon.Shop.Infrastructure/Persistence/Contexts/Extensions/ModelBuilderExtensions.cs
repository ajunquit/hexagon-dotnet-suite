using Hexagon.Shop.Infrastructure.Persistence.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Hexagon.Shop.Infrastructure.Persistence.Contexts.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void ApplyEntityConfigurations(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new OrderConfiguration());
        }

    }
}
