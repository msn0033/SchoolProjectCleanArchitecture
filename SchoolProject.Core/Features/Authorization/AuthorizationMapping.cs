using AutoMapper;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization
{
    public class AuthorizationMapping: Profile
    {
        public AuthorizationMapping()
        {
        
            //Role to Dto
            CreateMap<Role, RoleResponse>();
        

        }
    }
}
