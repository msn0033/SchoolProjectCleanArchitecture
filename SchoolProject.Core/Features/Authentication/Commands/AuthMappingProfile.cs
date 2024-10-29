using AutoMapper;
using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands
{
    public class AuthMappingProfile:Profile
    {

        public AuthMappingProfile()
        {
            CreateMap<AuthResult, AuthResultDto>();
        }
    }
}
