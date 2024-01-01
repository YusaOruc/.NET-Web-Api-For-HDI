using Auth.Core.Dtos.User;
using Auth.Core.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Data.Core.DbContexts;
using Data.Core.Dtos;
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
        private readonly RoleManager<IdentityRole> _roleManager;
        public UserService(RoleManager<IdentityRole> roleManager,UserManager<ApplicationUser> userManager, HdiDbContext context, IMapper mapper, ISessionService sessionService)
        {
            _userManager = userManager;
            _context = context;
            _mapper = mapper;
            _sessionService = sessionService;
            _roleManager = roleManager;
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
            obj.Role = roles.FirstOrDefault();


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

        public async Task<IdentityResult> Add(UserDto dto)
        {
            // Kullanıcı adının (UserName) benzersiz olmasını sağlamak için kontrol
            if (await _userManager.FindByNameAsync(dto.Username) != null)
            {
                // Kullanıcı adı zaten kullanımda ise hata döndür
                return IdentityResult.Failed(new IdentityError { Description = "Username is already taken." });
            }

            var user = new ApplicationUser { UserName = dto.Username, Email = dto.Username };

            // Kullanıcının belirtilen rolu ile kaydedilmesi
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (result.Succeeded)
            {
                if (!await _roleManager.RoleExistsAsync(dto.Role))
                {
                    // Belirtilen rol henüz yoksa, rolü oluşturun
                    await _roleManager.CreateAsync(new IdentityRole(dto.Role));
                }

                // Kullanıcıya belirtilen rol atanıyor
                await _userManager.AddToRoleAsync(user, dto.Role);
            }

            return result;
        }
        public async Task<IEnumerable<UserNameDto>> GetNameList()
        {
            var result = await _userManager.Users.AsNoTracking()
                .Select(t => new UserNameDto
                {
                    Id = t.Id,
                    Name = t.UserName
                })
                .OrderByDescending(t => t.Name)
                .ToListAsync();

            return result;
        }
    }
}
