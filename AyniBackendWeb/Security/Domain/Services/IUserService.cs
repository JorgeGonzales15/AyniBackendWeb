using AyniBackendWeb.Security.Domain.Models;
using AyniBackendWeb.Security.Domain.Services.Communication;

namespace AyniBackendWeb.Security.Domain.Services;

public interface IUserService
{
    Task<AuthenticationResponse> Authenticate(AuthenticationRequest model);
    Task<IEnumerable<User>> ListAsync();
    Task<User> GetByIdAsync(int id);
    Task RegisterAsync(RegisterRequest model);
    Task UpdateAsync(int id, UpdateRequest model);
    Task DeleteAsync(int id);
}