using Microsoft.CodeAnalysis;
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
        public void ManageUserRolesPartialMapping()
        {
            CreateMap<Role, RoleByUser>()
             .ForMember(des => des.Id, su => su.MapFrom(x => x.Id))
             .ForMember(des => des.NameAr, su => su.MapFrom(x => x.Localize(x.NameAr, x.NameEn)))
             .ForMember(des => des.NameEn, su => su.MapFrom(x => x.Localize(x.NameAr, x.NameEn)))
             .ForMember(des => des.Name, su => su.MapFrom(x => x.Name));

         



        }
    }
}
