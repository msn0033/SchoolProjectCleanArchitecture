using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.ModelsHelper
{
    public static class ClaimsStore
    {
        public static List<Claim> Claims = new List<Claim>
        {
            new Claim("Create Student","true"),
            new Claim("Edit Student","true"),
            new Claim("Delete Student","true"),
            new Claim("Detalis  Student","true"),

             new Claim("Create Department","true"),
            new Claim("Edit Department","true"),
            new Claim("Delete Department","true"),
            new Claim("Detalis  Department","true")

        };
    }
}
