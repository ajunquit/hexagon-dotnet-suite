using System.Text.Json;

namespace Hexagon.Shop.Domain.Common.Mappers
{
    public static class MapperExtension
    {
        public static T MapTo<T>(this object value)
        {
            return JsonSerializer.Deserialize<T>(
                JsonSerializer.Serialize(value)
            )!;
        }
    }
}
