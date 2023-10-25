using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Shared.Persistence.Contexts;

namespace AyniBackendWeb.Shared.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private readonly AppDbContext _context;
    
    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public async Task CompleteAsync()
    {
        await _context.SaveChangesAsync();

    }
}