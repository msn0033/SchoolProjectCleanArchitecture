using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Commands.Create;
using SchoolProject.Core.Features.ApplicationUser.Queries.GetUsersPaginatedList;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser
{
    internal class UserMapping: Profile
    {
        public UserMapping()
        {
            //Commands to user
            CreateMap<CreateUserCommand, User>();

            //User to Dto(Response)
            CreateMap<User, GetUsersPaginatedListResponse>();

        }
    }
}
