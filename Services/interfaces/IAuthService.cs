using Microsoft.AspNetCore.Identity;
using OctaPro.Models;

namespace OctaPro.Services.interfaces
{
    
    public interface IAuthService
    {
        Task<IdentityResult> RegisterAsync(string email, string password);
        Task<string?> LoginAsync(string email, string password);
        Task LogoutAsync();
        Task<User?> GetCurrentUserAsync();
    }
}
