using Auth.Core.Dtos.User;
using Auth.Core.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Core.DbContexts;
using Data.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.Services
{
    public class UserService : IUserService
    {
        private readonly HdiDbContext _context;
        private readonly IMapper _mapper;
        private readonly ISessionService _sessionService;
        private readonly UserManager<ApplicationUser> _userManager;
        public UserService(UserManager<ApplicationUser> userManager, HdiDbContext context, IMapper mapper, ISessionService sessionService)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _sessionService = sessionService;
        }
        public async Task<UserListDto> Get(string id)
        {
            var roles=new List<string>();
            var user = await _userManager.FindByIdAsync(id);
            if (user != null)
            {
                roles = (List<string>)await _userManager.GetRolesAsync(user);
            }
            var obj = _mapper.Map<UserListDto>(user);
            obj.Roles = roles;


            return obj;
        }

        public async Task<IEnumerable<UserListDto>> GetList()
        {
            var result = await _userManager.Users
                .AsNoTracking()
                .ProjectTo<UserListDto>(_mapper.ConfigurationProvider)
                .OrderByDescending(t => t.UserName)
                .ToListAsync();

            return result;
        }
    }
}
