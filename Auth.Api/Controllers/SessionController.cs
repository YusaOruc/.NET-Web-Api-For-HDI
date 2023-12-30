using Auth.Core.Interfaces;
using Auth.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Api.Controllers
{
    [Route("api/authModule/[controller]")]
    [ApiController]
    public class SessionController : ControllerBase
    {
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService)
        {
            _sessionService = sessionService;
        }


        [HttpPost("AuthenticatedUserId")]
        [Authorize] // Sadece oturum açmış kullanıcılar için
        public async Task<string> GetAuthenticatedUserId()
        {
            var result = await _sessionService.GetAuthenticatedUserIdAsync();
            return result;
        }
    }
}
