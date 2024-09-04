using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface ICurrentUserService
    {
        int UserId();
        Task<User> GetUserAsync();
        bool IsAuthenticated();
        Task<List<string>> GetRolesByCurrentUserAsync();
    }
}
