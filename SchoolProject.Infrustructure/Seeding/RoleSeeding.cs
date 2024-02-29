using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class RoleSeeding
    {
        public static async Task RoleAddAsync(RoleManager<Role> _roleManager)
        {
            if(!await _roleManager.Roles.AnyAsync())
            {
                await _roleManager.CreateAsync(new Role {Name=RolesEnum.SuperAdmin.ToString()});
                await _roleManager.CreateAsync(new Role { Name = RolesEnum.Admin.ToString() });
                await _roleManager.CreateAsync(new Role { Name = RolesEnum.Basic.ToString() });
            }

        }
    }
}
