using SchoolProject.Data.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<string> GetJWTToken(User user);
    }
}
