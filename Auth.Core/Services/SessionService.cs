using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Services
{
    public class SessionService: ISessionService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<IdentityUser> _userManager;
        public SessionService(IHttpContextAccessor httpContextAccessor, UserManager<IdentityUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        public async Task<string> GetAuthenticatedUserIdAsync()
        {
            // HttpContext'ten kullanıcının adını al
            string userName = _httpContextAccessor.HttpContext.User.Identity.Name;

            // UserManager aracılığıyla kullanıcının ID'sini al
            var user = await _userManager.FindByNameAsync(userName);

            if (user != null)
            {
                string userId = await _userManager.GetUserIdAsync(user);
                return userId;
            }

            return null; // Kullanıcı bulunamazsa null dönebilirsiniz ya da bir hata mekanizması ekleyebilirsiniz.
        }
    }
}
