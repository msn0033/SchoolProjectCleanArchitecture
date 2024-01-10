
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
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

        public AuthorizationService(RoleManager<Role> roleManager,UserManager<User> userManager)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
        }
        public async Task<bool> AddRoleAsync(string NameEn, string NameAr)
        {
            var role = new Role 
            {
                Name = NameEn,
                NameEn = NameEn,
                NameAr = NameAr
            };
            var result=await _roleManager.CreateAsync(role);
            if (result.Succeeded)
            {
                return true;
            }
            return false;
        }

        public Task<IQueryable<Role>> GetAllRoles()
        {
            var roles = _roleManager.Roles;

            return Task.FromResult(roles);
        }
        public async Task<Role> GetRoleByIdAsync(int id)
        {
            var role=await _roleManager.FindByIdAsync(id.ToString());
            return role!;
        }

        public async Task<Role> GetRoleByNameAsync(string name)
        {
            var role = await _roleManager.Roles.AsNoTracking()
            .FirstOrDefaultAsync(x => x.NameAr.Contains(name) || x.NameEn.Contains(name));
            return role!;
        }

        public async Task<IList<string>> GetRolesByUserAsync(int id)
        {
            var user= await _userManager.FindByIdAsync(id.ToString());

            if (user != null)
            {
                var rolesbyuser =await _userManager.GetRolesAsync(user);
                return rolesbyuser;
            }
            return null!;
        }

        public async Task<bool> IsExistRoleAsync(string search)
        {
            var result = await _roleManager.Roles
                .FirstOrDefaultAsync(x => x.NameEn.Contains(search) || x.NameAr.Contains(search));
            if (result != null)
                return true;
            return false;
        }
    }
}
