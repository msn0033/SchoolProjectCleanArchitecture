using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IAuthorizationService
    {
        Task<bool>AddRoleAsync(string NameEn,string NameAr);
        Task<bool> IsExistRoleAsync(string search);
    }
}
