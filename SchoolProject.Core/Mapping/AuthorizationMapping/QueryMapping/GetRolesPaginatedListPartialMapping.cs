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
        public void GetRolesPaginatedListPartialMapping()
        {
            CreateMap<Role, GetRolesPaginatedListQueryResponse>()
           .ForMember(des => des.Id, src => src.MapFrom(x => x.Id))
           .ForMember(des => des.Name, src => src.MapFrom(x => x.Localize(x.NameAr, x.NameEn)));

        }
    }
}
