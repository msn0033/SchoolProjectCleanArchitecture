using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Filters
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = false)]
    public class CheckPermissionAttribute:Attribute
    {
        public string Permission { get; }
        public CheckPermissionAttribute(string permission)
        {
            this.Permission = permission;  
        }
    }
}
