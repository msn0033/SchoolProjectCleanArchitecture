using AutoMapper;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Mapping.ApplicationUserMapping;
using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class UserProfile: Profile
    {
       public void  AddUserCommandMapping()
        {
            CreateMap<AddUserCommand, User>();

        }
    }
}
