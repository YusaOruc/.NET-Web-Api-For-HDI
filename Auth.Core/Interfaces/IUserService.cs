using Auth.Core.Dtos.User;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Kullanıcı Detay
        /// </summary>
        /// <param name="id">Kullanıcı Id</param>
        /// <returns></returns>
        Task<UserListDto> Get(string id);

        /// <summary>
        /// Kullanıcı Listeleme
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserListDto>> GetList();

        /// <summary>
        /// Kullanıcı Ekleme
        /// </summary>
        /// <param name="dto"></param>
        /// <returns></returns>
        Task<IdentityResult> Add(UserDto dto);

        /// <summary>
        /// Kullanıcı Adlarını listeler
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<UserNameDto>> GetNameList();
    }
}
