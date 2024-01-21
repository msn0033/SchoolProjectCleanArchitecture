using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.DTOs
{
    public class ManageUserRolesDTOsResponse
    {
        public int UserId { get; set; }
        public IList<UserRoles>? UserRoles { get; set; }
    }
    public class UserRoles
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
