using AyniBackendWeb.Shared.Persistence.Contexts;

namespace AyniBackendWeb.Shared.Persistence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
}