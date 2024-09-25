using SchoolProject.Data.Entities;
using System.Net.NetworkInformation;

namespace SchoolProject.Data.AppMetaData
{
    public static class PathRoute
    {
        public const string id = "{id}";
        public const string root = "Api";
        public const string Version = "V1";
        public const string Rule = root + "/" + Version + "/";
        public static class StudentsRoute
        {
            public const string prefix = Rule + "students/";
            public const string List = prefix + "List";
            public const string GetById = prefix + "GetById/" + id;
            public const string Create = prefix + "Create";
            public const string Edit = prefix + "Edit";
            public const string Delete = prefix + id;
            public const string Paginated = prefix + "Paginated";

        }
        public static class ApplicationUsersRoute
        {
            public const string prefix = Rule + "ApplicationUsers/";
            public const string Create = prefix + "Create";
            public const string Paginated = prefix + "Paginated";
        }
        public static class AuthenticationRoute
        {
            public const string prefix = Rule + "Authentication/";
           
            public const string sigin = prefix + "sigin"; 
            public const string RefreshToken = prefix + "Refresh-Token";
        }
        public static class AuthorizationRoute
        {
            public const string prefix = Rule + "Authorization/";
            //roles
            public const string Roles = prefix + "Roles/";
        
            public const string Create = Roles + "Create";
            public const string RolesPaginated = Roles + "RolesPaginated";
            public const string GetRoleById = Roles + "GetRoleById";
            public const string GetRoleByName = Roles + "GetRoleByName";
            public const string Get_Manage_Roles_By_UserId = Roles + "Get_Manage_Roles_By_UserId"; 
            public const string Update_Manage_Roles_By_UserId = Roles + "Update_Manage_Roles_By_UserId";

            //claims
            public const string Claims = prefix + "Claims/";
            public const string Get_Manage_Claims_By_UserId = Claims + "Get_Manage_Claims_By_UserId/" + id;
            public const string Update_Manage_Claims_By_UserId = Claims + "Update_Manage_Claims_By_UserId/";


        }

        public static class DepartmentRoute
        {
            public const string prefix = Rule + "Dapartments/";
            public const string Dapartment = prefix;
            public const string List = Dapartment + "List/";
            public const string GetById = Dapartment + "GetById/"+id;
            public const string GetViewDepartmentwithStudentCount = Dapartment + "GetViewDepartmentwithStudentCount";



        }


    }
}
