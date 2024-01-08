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
        public void GetRoleByNameQueryPartialMapping()
        {
            CreateMap<Role, GetRoleByNameQueryResponse>()
                .ForMember(des => des.name, src => src.MapFrom(x => x.Localize(x.NameAr,x.NameEn)));

        }
    }
}
