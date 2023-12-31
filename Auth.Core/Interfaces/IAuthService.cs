using Auth.Core.Dtos;
using Microsoft.AspNetCore.Identity;

namespace Auth.Core.Interfaces
{
    public interface IAuthService
    {
        /// <summary>
        /// Çıkış
        /// </summary>
        /// <returns></returns>
        Task<bool> Logout();
        Task<IdentityResult> RegisterUser(string username, string password, string role);
        Task<LoginResultDto> LoginUser(string username, string password);
        string GenerateTokenString(string username, string password);
    }
}
