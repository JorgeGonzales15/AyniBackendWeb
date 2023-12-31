using AyniBackendWeb.Ayni.Domain.Models;

namespace AyniBackendWeb.Ayni.Domain.Repositories;

public interface IOrderRepository
{
    Task<IEnumerable<Order>> ListAsync();
    Task AddAsync(Order order);
    Task<Order> FindByIdAsync(int orderId);
    Task<IEnumerable<Order>> FindByUserIdAsync(int userId);
    void Update(Order order);
    void Remove(Order order);
}