using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Repositories;
using AyniBackendWeb.Shared.Persistence.Contexts;
using AyniBackendWeb.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace AyniBackendWeb.Ayni.Persistence.Repositories;

public class CropRepository : BaseRepository, ICropRepository
{
    public CropRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Crop>> ListAsync()
    {
        return await _context.Crops
            .Include(p => p.User)
            .ToListAsync();
    }

    public async Task AddAsync(Crop crop)
    {
        await _context.Crops.AddAsync(crop);

    }

    public async Task<Crop> FindByIdAsync(int cropId)
    {
        return await _context.Crops
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Id == cropId);

    }

    public async Task<Crop> FindByTitleAsync(string name)
    {
        return await _context.Crops
            .Include(p => p.User)
            .FirstOrDefaultAsync(p => p.Name == name);
    }

    public async Task<IEnumerable<Crop>> FindByUserIdAsync(int userId)
    {
        return await _context.Crops
            .Where(p => p.UserId == userId)
            .Include(p => p.User)
            .ToListAsync();

    }

    public void Update(Crop crop)
    {
        _context.Crops.Update(crop);

    }

    public void Remove(Crop crop)
    {
        _context.Crops.Remove(crop);

    }
}