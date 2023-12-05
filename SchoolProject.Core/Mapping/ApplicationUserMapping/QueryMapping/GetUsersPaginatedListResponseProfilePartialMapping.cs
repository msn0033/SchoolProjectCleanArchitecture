using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Queries.Responses;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class UserProfile : Profile
    {
        public void GetUsersPaginatedListResponseMapping()
        {
            CreateMap<User, GetUsersPaginatedListResponse>();
        }
    }
}
