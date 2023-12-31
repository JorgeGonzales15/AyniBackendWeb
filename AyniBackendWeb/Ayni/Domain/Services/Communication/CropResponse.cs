using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Shared.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services.Communication;

public class CropResponse : BaseResponse<Crop>
{
    public CropResponse(string message) : base(message)
    {
    }
    public CropResponse(Crop resource) : base(resource)
    {
    }

}