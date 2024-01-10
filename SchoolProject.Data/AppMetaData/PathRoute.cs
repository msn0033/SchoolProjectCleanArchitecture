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

            public const string Create = prefix + "Create";
            public const string RolesPaginated = prefix + "RolesPaginated";
            public const string GetRoleById = prefix + "GetRoleById";
            public const string GetRoleByName = prefix + "GetRoleByName";
            public const string ManageUserRoles = prefix + "ManageUserRoles";

            
        }


    }
}
