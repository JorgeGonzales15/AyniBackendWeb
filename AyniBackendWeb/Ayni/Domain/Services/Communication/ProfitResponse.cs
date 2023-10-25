using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Shared.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services.Communication;

public class ProfitResponse : BaseResponse<Profit>
{
    public ProfitResponse(string message) : base(message)
    {
    }
    public ProfitResponse(Profit resource) : base(resource)
    {
    }
}