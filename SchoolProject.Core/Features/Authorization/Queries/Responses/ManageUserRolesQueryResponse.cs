using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Responses
{
    public class ManageUserRolesQueryResponse
    {
        public int UserId { get; set; }
        public IList<RoleByUser>? RolesByUser { get; set; }
    }
    public class RoleByUser
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? NameEn { get; set; }
        public string? NameAr { get; set; }
        public bool IsActive { get; set; } = false;
    }
}
