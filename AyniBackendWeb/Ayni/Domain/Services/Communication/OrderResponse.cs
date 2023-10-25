using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Shared.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services.Communication;

public class OrderResponse : BaseResponse<Order>
{
    public OrderResponse(string message) : base(message)
    {
    }
    public OrderResponse(Order resource) : base(resource)
    {
    }
}