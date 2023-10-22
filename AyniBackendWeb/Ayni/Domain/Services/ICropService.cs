using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services;

public interface ICropService
{
    Task<IEnumerable<Crop>> ListAsync();
    Task<IEnumerable<Crop>> ListByCategoryIdAsync(int userId);
    Task<CropResponse> SaveAsync(Crop crop);
    Task<CropResponse> UpdateAsync(int cropId, Crop 
        crop);
    Task<CropResponse> DeleteAsync(int cropId);
}