using Auth.Core.Dtos.User;
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
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService; // Örnek olarak bir kullanıcı veritabanı işlemleri için bir repository

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        /// <summary>
        ///     Kullanıcı
        /// </summary>
        /// <param name="id"></param>
        /// <response code="200">Kullanıcı bilgileri</response>
        [Authorize]
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(UserListDto), 200)]
        public async Task<ActionResult<UserListDto>> GetUser([FromRoute] string id)
        {
            var obj = await _userService.Get(id);

            if (obj == null)
            {
                return NotFound();
            }

            return obj;
        }

        /// <summary>
        ///     Kullanıcı Listeleme
        /// </summary>
        /// <response code="200">Başarılı Listeleme</response>
        /// <response code="400">Eksik olan Fieldlar</response>
        [Authorize]
        [HttpGet]
        [ProducesResponseType(typeof(ValidationProblemDetails), 400)]
        [ProducesResponseType(typeof(IEnumerable<UserListDto>), 200)]
        public async Task<ActionResult<IEnumerable<UserListDto>>> GetUsers()
        {
            var obj = await _userService.GetList();

            return Ok(obj);
        }
    }
}
