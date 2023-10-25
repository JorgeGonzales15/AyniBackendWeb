using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Shared.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services.Communication;

public class CostResponse : BaseResponse<Cost>
{
    public CostResponse(string message) : base(message)
    {
    }
    public CostResponse(Cost resource) : base(resource)
    {
    }
}