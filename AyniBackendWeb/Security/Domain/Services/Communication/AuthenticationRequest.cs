using System.ComponentModel.DataAnnotations;

namespace AyniBackendWeb.Security.Domain.Services.Communication;

public class AuthenticationRequest
{
    [Required] public string Username { get; set; }
    
    [Required] public string Email { get; set; }

    [Required] public string Password { get; set; }
}