using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Shared.Persistence.Contexts;
using AyniBackendWeb.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniBackendWeb.Ayni.Persistence.Repositories;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Order>> ListAsync()
    {
        return await _context.Orders
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Order order)
    {
        await _context.Orders.AddAsync(order);
    }

    public async Task<Order> FindByIdAsync(int orderId)
    {
        return await _context.Orders
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == orderId);
    }

    public async Task<IEnumerable<Order>> FindByUserIdAsync(int userId)
    {
        return await _context.Orders
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();
    }

    public void Update(Order order)
    {
        _context.Orders.Update(order);
    }

    public void Remove(Order order)
    {
        _context.Orders.Remove(order);
    }
}