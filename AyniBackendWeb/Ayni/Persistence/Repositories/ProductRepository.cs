using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Shared.Persistence.Contexts;
using AyniBackendWeb.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniBackendWeb.Ayni.Persistence.Repositories;

public class ProductRepository : BaseRepository, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> ListAsync()
    {
        return await _context.Products.ToListAsync();
    }

    public async Task AddAsync(Product product)
    {
        await _context.Products.AddAsync(product);
    }

    public async Task<Product> FindByIdAsync(int productId)
    {
        return await _context.Products.FindAsync(productId);
    }
    
    public void Update(Product product)
    {
        _context.Products.Update(product);
    }

    public void Remove(Product product)
    {
        _context.Products.Remove(product);
    }
}