using Auth.Core.Dtos.User;
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
    }
}
