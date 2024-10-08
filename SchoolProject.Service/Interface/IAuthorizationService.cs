﻿using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Request;
using SchoolProject.Data.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IAuthorizationService
    {
        Task<bool>AddRoleAsync(string Name);
        Task<bool> IsExistRoleAsync(string search);
        Task<Role> GetRoleByIdAsync(int id);
        Task<Role> GetRoleByNameAsync(string name);
        Task<IList<string>> GetRolesByUserIdAsync(int id);
        Task<IQueryable<Role>> GetAllRolesAsync();

       Task<ManageUserRolesResult> GetManageRolesByUserIdAsync(User user);
        Task<string> UpdateManageRolesByUserIdAsync(UpdateUserRolesRequest request);

        //Claims
        Task<ManageUserClaimsResult> GetManageUserClaimsDataAsync(User user);
        Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request);




    }
}
