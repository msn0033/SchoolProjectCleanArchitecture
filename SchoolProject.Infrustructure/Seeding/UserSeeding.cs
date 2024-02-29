using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using SchoolProject.Data.Permission;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class UserSeeding
    {
        public static async Task addUserSuperAdminAsync(UserManager<User> _userManager, RoleManager<Role> _roleManager)
        {
            try
            {
                if (!await _userManager.Users.AnyAsync())
                {
                    var UserSuperAdmin = new User
                    {
                        FullName = Permission.FullNameSuperAdmin,
                        UserName = Permission.UserNameSuperAdmin,
                        Email = Permission.EmailSuperAdmin,
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    //Create UserSuperAdmin
                    await _userManager.CreateAsync(UserSuperAdmin, Permission.PasswordSuperAdmin);

                    //add role SuperAdmin for UserSuperAdmin
                    await _userManager.AddToRoleAsync(UserSuperAdmin, RolesEnum.SuperAdmin.ToString());

                    // role by name
                    var role = await _roleManager.FindByNameAsync(RolesEnum.SuperAdmin.ToString());
                    //AllCalims by role
                    var AllCalimsByRole = await _roleManager.GetClaimsAsync(role);

                    //Permission Generate
                    var PermissionList = Permission.PermissionList();

                    foreach (var PermissionValue in PermissionList)
                    {
                        if (!AllCalimsByRole.Any(x => x.Type == CustomClaimTypes.Permission && x.Value == PermissionValue))
                        {
                            await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, PermissionValue));
                        }
                    }
                }
            }
            catch (Exception ex )
            {

                throw ex.InnerException;
            }
          
        }
    }
}
