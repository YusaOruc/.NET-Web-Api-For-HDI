using Auth.Core.Dtos;
using Auth.Core.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers
{
    [Route("api/authModule/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }
        [HttpPost("logout")]
        [Authorize] // Sadece oturum açmış kullanıcılar için
        public async Task<IActionResult> Logout()
        {
            await _authService.Logout(); // Oturumu kapat

            return Ok(new { Message = "Logout successful." });
        }
        [HttpPost("test")]
        [Authorize] // Sadece oturum açmış kullanıcılar için
        public async Task<string> Test()
        {
            var a = "Test";
            return a;
        }
        [HttpPost("login")]
        public async Task<LoginResultDto> Login(string username, string password)
        {
            var obj = await _authService.LoginUser(username, password);
            return obj;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(string username, string password)
        {
            var result = await _authService.RegisterUser(username, password);

            if (result.Succeeded)
            {
                return Ok(new { Message = "User registered successfully." });
            }

            return BadRequest(new { Message = "Error during registration.", Errors = result.Errors });
        }
    }
}
