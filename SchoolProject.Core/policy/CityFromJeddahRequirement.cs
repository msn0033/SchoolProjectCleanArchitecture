using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.policy
{
    public class CityFromJeddahRequirement:IAuthorizationRequirement
    {
        public string city { get; set; } = "Jeddah";
    }
}
