using OctaPro.Models;

namespace OctaPro.Services.interfaces
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(User user);
    }
    
}