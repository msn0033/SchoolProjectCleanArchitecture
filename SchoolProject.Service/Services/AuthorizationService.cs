
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.DTOs;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;

        public AuthorizationService(RoleManager<Role> roleManager, UserManager<User> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        public async Task<bool> AddRoleAsync(string Name)
        {
            var role = new Role { Name = Name };

            var result = await _roleManager.CreateAsync(role);

            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public Task<IQueryable<Role>> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles;

            return Task.FromResult(roles);
        }
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var role = await _roleManager.FindByIdAsync(id.ToString());
            if (role == null)
                return null!;
            return role;
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            var role = await _roleManager.FindByNameAsync(name);
            return role!;
        }

        public async Task<IList<string>> GetRolesByUserIdAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null)
                return null!;

            var rolesbyuser = await _userManager.GetRolesAsync(user);
            return rolesbyuser;
        }

        public async Task<bool> IsExistRoleAsync(string search)
        {
            var result = await _roleManager.FindByNameAsync(search);

            if (result == null)
                return false;
            return true;
        }
        public async Task<ManageUserRolesDTOsResponse> GetManageUserRolesDataAsync(User user)
        {
            var respons = new ManageUserRolesDTOsResponse();
            var roleslist = new List<UserRoles>();
            //roles
            var roles = await GetAllRolesAsync();
            foreach (var role in roles.ToList())
            {
                if (role.Name != null)
                {
                    var userrole = new UserRoles();
                    userrole.Id = role.Id;
                    userrole.Name = role.Name;
      
                    if (await _userManager.IsInRoleAsync(user, role.Name))
                    {
                        userrole.IsActive = true;
                    }
                    else 
                        userrole.IsActive = false;

                    roleslist.Add(userrole);
                }
            }
            respons.UserId = user.Id;
            respons.UserRoles = roleslist;

            return respons;

        }
        public async Task<string> UpdateUserRolesAsync(UpdateUserRolesRequest request)
        {
            var user = await _userManager.FindByIdAsync(request.UserId.ToString());
            if (user == null)
            {
                return "User Is Null";
            }
            var oldRoles = await _userManager.GetRolesAsync(user);
            var remove = await _userManager.RemoveFromRolesAsync(user, oldRoles);
            if (!remove.Succeeded)
            {
                return "error on Removeing old Roles";
            }
            var newRoles = request.UserRoles?.Where(x => x.IsActive).Select(x => x.Name);
            var result = await _userManager.AddToRolesAsync(user, newRoles!);
            if (!result.Succeeded)
            {
                return "error on add new Roles";
            }
            return "Success";
        }
    }
}
