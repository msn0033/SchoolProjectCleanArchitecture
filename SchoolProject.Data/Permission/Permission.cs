using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Permission
{
    public class Permission
    {


        public const string FullNameSuperAdmin = "SuperAdmin";
        public const string UserNameSuperAdmin = "SuperAdmin";
        public const string EmailSuperAdmin = "msn@3dads.com.sa";
        public const string PasswordSuperAdmin = "1234";

        public static List<string> GeneratePermissionsForModule(string module)
        {
            return new List<string>()
            {
                $"Permission.{module}.Create",
                $"Permission.{module}.View",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete"

            };


        }
        public static class Students
        {
            public const string Create = "Permission.Students.Create";
            public const string View = "Permission.Students.View";
            public const string Update = "Permission.Students.Update";
            public const string Delete = "Permission.Students.Delete";
        }

    }
}
