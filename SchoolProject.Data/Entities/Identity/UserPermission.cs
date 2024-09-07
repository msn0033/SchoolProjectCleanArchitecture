using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Identity
{
    public class UserPermission
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public string Permission { get; set; }
    }
}
