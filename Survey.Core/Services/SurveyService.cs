using AutoMapper;
using Data.Core.DbContexts;
using Data.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Survey.Core.Dtos.Survey;
using Survey.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Survey.Core.Services
{
    public class SurveyService : ISurveyService
    {
        private readonly HdiDbContext _context;
        private readonly IMapper _mapper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public SurveyService(HdiDbContext context, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _mapper = mapper;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Add(SurveyDto dto)
        {
            // HttpContext'ten ClaimsPrincipal al
            var claimsPrincipal = _httpContextAccessor.HttpContext.User;

            // Kullanıcının ID'sini al
            string userId = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier)?.Value;



            var created = DateTime.UtcNow;

            var obj = _mapper.Map<SurveyBase>(dto);

            obj.CreateDate = created;
            obj.LastUpdateDate = created;
            obj.Creator = Convert.ToInt32( userId);
            obj.Updater = Convert.ToInt32(userId);
        }
    }
}
