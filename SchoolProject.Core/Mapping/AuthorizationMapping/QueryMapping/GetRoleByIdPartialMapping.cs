using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.AuthorizationMapping
{
    public partial class AuthorizationProfile
    {
        public void GetRoleByIdQuery()
        {
            CreateMap<Role, GetRoleByIdQueryResponse>()
                .ForMember(des => des.Name, src => src.MapFrom(x => x.Localize(x.NameAr, x.NameEn)));
        }
    }
}
