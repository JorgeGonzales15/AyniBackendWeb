using AyniBackendWeb.Security.Domain.Models;

namespace AyniBackendWeb.Security.Authorization.Handlers.Interfaces;

public interface IJwtHandler
{
    public string GenerateToken(User user);
    public int? ValidateToken(string token);
}