using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.ApplicationUserMapping
{
    public partial class UserProfile:Profile
    {
        public UserProfile()
        {
            AddUserCommandMapping();
        }
    }
}
