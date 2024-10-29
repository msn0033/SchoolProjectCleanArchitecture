using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Permission
{
    public class Permission
    {

        //BasicUser
        public const string FullNameBaiscUser = "BaiscUser";
        public const string UserNameBaiscUser = "BaiscUser";
        public const string EmailBaiscUser = "msn0033@gmail.com";
        public const string PasswordBaiscUser = "P@ssw0rd";
        // superadmin
        public const string FullNameSuperAdmin = "SuperAdmin";
        public const string UserNameSuperAdmin = "SuperAdmin";
        public const string EmailSuperAdmin = "msn@3dads.com.sa";
        public const string PasswordSuperAdmin = "P@ssw0rd";


        public static List<string> GeneratePermissionsListForModule(string module)
        {
            return new List<string>()
            {
                $"Permission.{module}.Create",
                $"Permission.{module}.View",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete"

            };
        }

        public static List<string>GenerateAllPermission()
        {
            List<string> modules = new List<string>();
            foreach (var module in Enum.GetNames(typeof(ModuleEnum)))
            {
                modules.AddRange(Permission.GeneratePermissionsListForModule(module));//Create.NameController                        
            }
            return modules;
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
