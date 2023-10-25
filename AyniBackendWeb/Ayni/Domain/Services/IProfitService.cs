using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Ayni.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services;

public interface IProfitService
{
    Task<IEnumerable<Profit>> ListAsync();
    Task<IEnumerable<Profit>> ListByUserIdAsync(int userId);
    Task<ProfitResponse> SaveAsync(Profit profit);
    Task<ProfitResponse> UpdateAsync(int profitId, Profit 
        profit);
    Task<ProfitResponse> DeleteAsync(int profitId);
}