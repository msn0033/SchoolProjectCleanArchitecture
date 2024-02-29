using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Permission
{
    public static class Permission
    {
        #region Const
        public const string UserNameSuperAdmin = "SuperAdmin";
        public const string FullNameSuperAdmin = "SuperAdmin";
        public const string EmailSuperAdmin = "SuperAdmin@SuperAdmin.com";
        public const string PasswordSuperAdmin = "123456";

        public const string Na = "";
       

        public static class Students
        {
            public const string View = "Permission.Students.View";
            public const string Create = "Permission.Students.Create";
            public const string Edit = "Permission.Students.Edit";
            public const string Delete = "Permission.Students.Delete";
        }
        public static class Departments
        {
            public const string View = "Permission.Departments.View";
            public const string Create = "Permission.Departments.Create";
            public const string Edit = "Permission.Departments.Edit";
            public const string Delete = "Permission.Departments.Delete";
        }

        #endregion
        private static List<string> GeneratePerimssionFromModule(string module)
        {
            var list = new List<string>
            {
                $"Permission.{module}.View",
                $"Permission.{module}.Create",
                $"Permission.{module}.Edit",
                $"Permission.{module}.Delete",
            };
            return list;
        }
        public static List<string> PermissionList()
        {
            var allPermission = new List<string>();
            foreach (var module in Enum.GetValues(typeof(PermissionModuleName)))
            {
                allPermission.AddRange(GeneratePerimssionFromModule(module.ToString()));
            }
            return allPermission;
        }
    }
}
