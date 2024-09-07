using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Result
{
    public class ManageUserRolesResult
    {
        public int UserId { get; set; }
        public IList<UserRoles>? UserRoles { get; set; }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsSelected { get; set; } = false;
    }
}
