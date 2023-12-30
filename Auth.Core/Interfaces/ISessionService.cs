using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Interfaces
{
    public interface ISessionService
    {
        /// <summary>
        /// Authentice olmuş kullanıcın idsini getirir
        /// </summary>
        /// <returns></returns>
        Task<string> GetAuthenticatedUserIdAsync();
    }
}
