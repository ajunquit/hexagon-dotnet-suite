namespace Hexagon.Shop.Application.Dashboard.Dtos
{
    public class ChartPropertiesResponse
    {
        public string Title { get; set; }
        public IEnumerable<string> Labels { get; set; }
        public IEnumerable<int> Data { get; set; }
        public IEnumerable<string>? Colors { get; set; }
    }
}
