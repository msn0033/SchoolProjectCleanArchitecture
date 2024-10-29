using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Base
{
    public class ManageUserRolesResult
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public IList<UserRoles>? UserRoles { get; set; }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
