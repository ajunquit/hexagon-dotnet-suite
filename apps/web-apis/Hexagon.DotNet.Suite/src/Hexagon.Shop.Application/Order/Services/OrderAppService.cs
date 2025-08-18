using Hexagon.Shop.Application.Order.Dtos;
using Hexagon.Shop.Application.Order.Services;
using Hexagon.Shop.Domain.Common.Enums;
using Hexagon.Shop.Domain.Common.Interfaces;
using Hexagon.Shop.Domain.Common.Mappers;
using Hexagon.Shop.Domain.Orders.Enums;
using EntityOrder = Hexagon.Shop.Domain.Orders.Entity.Order;

namespace Hexagon.Shop.Application.OrderEntity.Services
{
    public class OrderAppService(IUnitOfWorkAsync unitOfWorkAsync) : IOrderAppService
    {
        private readonly IUnitOfWorkAsync _unitOfWorkAsync = unitOfWorkAsync;

        public async Task<OrderResponse> AddOrderAsync(OrderRequest request)
        {
            request.Id = Guid.NewGuid();
            var order = MapToOrder(request, string.Empty);
            var result = await _unitOfWorkAsync.OrderRepository.InsertAsync(order);
            await _unitOfWorkAsync.SaveChangesAsync();
            return MapperExtension.MapTo<OrderResponse>(request);
        }

        public async Task<IEnumerable<OrderResponse>> GetAllOrdersAsync()
        {
            var orders = await _unitOfWorkAsync.OrderRepository.GetAllAsync();
            orders = GetOrders(orders);

            return MapToOrders(orders);
        }

        private static IEnumerable<EntityOrder> GetOrders(IEnumerable<EntityOrder> orders)
        {
            return orders
                .Select(MapEntituOrder)
                .ToList();
        }

        private static EntityOrder MapEntituOrder(EntityOrder o)
        {
            return new EntityOrder
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                CustomerName = o.Customer.Name,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = o.Status,
                Notes = o.Notes,
                Customer = o.Customer,
                CreatedBy = string.Empty
            };
        }

        public async Task<OrderResponse?> GetOrderByIdAsync(Guid id)
        {
            var order = await _unitOfWorkAsync.OrderRepository.GetAsync(id);
            return MapperExtension.MapTo<OrderResponse>(order);
        }

        public async Task<bool> EditOrderAsync(Guid id, OrderRequest request)
        {
            var existing = await _unitOfWorkAsync.OrderRepository.GetAsync(id);
            if (existing == null)
                return false;

            existing.CustomerId = request.CustomerId;
            existing.OrderDate = request.OrderDate;
            existing.Status = GetStatus(request.Status);
            existing.DeliveryDate = request.DeliveryDate;
            existing.TotalAmount = request.TotalAmount;
            existing.UpdatedDate = DateTime.UtcNow;
            existing.UpdatedBy = string.Empty;
            existing.Notes = request.Notes;

            await _unitOfWorkAsync.OrderRepository.UpdateAsync(existing);
            await _unitOfWorkAsync.SaveChangesAsync();
            return true;
        }

        private static EnumOrderStatus GetStatus(string status) =>
        status switch
        {
            "pending" => EnumOrderStatus.Pending,
            "completed" => EnumOrderStatus.Completed,
            "cancelled" => EnumOrderStatus.Cancelled,
            _ => throw new ArgumentOutOfRangeException(nameof(status), $"Valor de estado no válido: {status}")
        };


        public async Task<bool> DeleteOrderAsync(Guid id)
        {
            var existing = await _unitOfWorkAsync.OrderRepository.GetAsync(id);
            if (existing == null)
                return false;

            existing.IsActive = EnumActiveRecord.No;
            existing.UpdatedDate = DateTime.UtcNow;

            await _unitOfWorkAsync.OrderRepository.UpdateAsync(existing); // delete logic marks as inactive
            await _unitOfWorkAsync.SaveChangesAsync();
            return true;
        }

        public static EntityOrder MapToOrder(OrderRequest request, string createdBy)
        {
            return new EntityOrder
            {
                Id = request.Id,
                OrderNumber = request.OrderNumber,
                CustomerId = request.CustomerId,
                CustomerName = request.CustomerName,
                OrderDate = request.OrderDate,
                DeliveryDate = request.DeliveryDate,
                TotalAmount = request.TotalAmount,
                Status = GetStatus(request.Status),
                Notes = request.Notes,
                IsActive = EnumActiveRecord.Yes,
                CreatedBy = createdBy,
                CreatedDate = DateTime.UtcNow,
                UpdatedBy = null,
                UpdatedDate = null
            };
        }

        public static IEnumerable<OrderResponse> MapToOrders(IEnumerable<EntityOrder> orders)
        {
            return orders.Select(o => new OrderResponse
            {
                Id = o.Id,
                OrderNumber = o.OrderNumber,
                CustomerId = o.CustomerId,
                CustomerName = o.CustomerName,
                OrderDate = o.OrderDate,
                DeliveryDate = o.DeliveryDate,
                TotalAmount = o.TotalAmount,
                Status = GetDescription(o.Status),
                Notes = o.Notes
            });
        }
        private static string GetDescription(EnumOrderStatus status)
        {
            return status switch
            {
                EnumOrderStatus.Pending => "pending",
                EnumOrderStatus.Completed => "completed",
                EnumOrderStatus.Cancelled => "cancelled",
                _ => "Unknown status"
            };
        }

    }
}
