using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services;

public interface IOrderService
{
    Task<IEnumerable<Order>> ListAsync();
    Task<IEnumerable<Order>> ListByUserIdAsync(int userId);
    Task<OrderResponse> SaveAsync(Order order);
    Task<OrderResponse> UpdateAsync(int orderId, Order 
        order);
    Task<OrderResponse> DeleteAsync(int orderId);
}