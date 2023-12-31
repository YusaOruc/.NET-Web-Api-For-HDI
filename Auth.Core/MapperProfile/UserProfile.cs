using Auth.Core.Dtos.User;
using AutoMapper;
using Data.Core.Entity;
using Data.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Auth.Core.MapperProfile
{
    public class UserProfile:Profile
    {
       
        public UserProfile()
        {
            CreateMap<ApplicationUser, UserListDto>();
        }
    }
}
