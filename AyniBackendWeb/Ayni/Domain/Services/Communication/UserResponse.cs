using AyniBackendWeb.Ayni.Domain.Models;
using AyniBackendWeb.Shared.Domain.Services.Communication;

namespace AyniBackendWeb.Ayni.Domain.Services.Communication;

public class UserResponse : BaseResponse<User>
{
    public UserResponse(string message, User resource) : base(message, resource)
    {
    }
}