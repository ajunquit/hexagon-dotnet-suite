using Hexagon.Shop.Application.Dashboard.Dtos;
using Hexagon.Shop.Domain.Common.Enums;
using Hexagon.Shop.Domain.Common.Interfaces;
using System.Globalization;

namespace Hexagon.Shop.Application.Dashboard.Services.Impl
{
    public class CustomerDashboardAppService : ICustomerDashboardAppService
    {
        private readonly IUnitOfWorkAsync _unitOfWork;
        public CustomerDashboardAppService(IUnitOfWorkAsync customerRepository)
        {
            _unitOfWork = customerRepository;
        }
        public async Task<ChartPropertiesResponse> GetNewClientsByLastMonthAsync(int lastMonths)
        {
            if (lastMonths <= 0) throw new ArgumentOutOfRangeException(nameof(lastMonths));

            var nowUtc = DateTime.UtcNow;
            var start = new DateTime(nowUtc.Year, nowUtc.Month, 1).AddMonths(-(lastMonths - 1));
            var endExcl = new DateTime(nowUtc.Year, nowUtc.Month, 1).AddMonths(1); // exclusivo

            var clients = await _unitOfWork.CustomerRepository.GetAllAsync();

            // Si quieres solo activos, descomenta:
            clients = clients.Where(c => c.IsActive == EnumActiveRecord.Yes).ToList();

            var inRange = clients.Where(c => c.CreatedDate >= start && c.CreatedDate < endExcl);

            // Diccionario Year-Month → Count
            var monthCounts = inRange
                .GroupBy(c => new { c.CreatedDate.Year, c.CreatedDate.Month })
                .ToDictionary(
                    g => new DateTime(g.Key.Year, g.Key.Month, 1),
                    g => g.Count()
                );

            var culture = new CultureInfo("es-ES"); // o "es-EC"
            var labels = new List<string>(lastMonths);
            var values = new List<int>(lastMonths);

            // Rellenar todos los meses (incluye los que no tienen registros)
            for (int i = 0; i < lastMonths; i++)
            {
                var m = start.AddMonths(i);
                labels.Add(m.ToString("MMM yyyy", culture)); // ej: "ene 2025"
                values.Add(monthCounts.TryGetValue(m, out var cnt) ? cnt : 0);
            }

            return new ChartPropertiesResponse
            {
                Title = "Nuevos clientes por mes",
                Labels = labels,
                Data = values
            };
        }
    }
}
