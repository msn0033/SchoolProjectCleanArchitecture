using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using SchoolProject.Data.Permission;
using SchoolProject.Infrustructure.Context;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolProject.Infrustructure.Seeding
{
    public static class UserSeeding
    {


        public static async Task SeedBaiscUserAsync(UserManager<User> _userManager, RoleManager<Role> _roleManager, AppDbContext _dbContext)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(Permission.EmailBaiscUser);
                if (user == null)
                {
                    var BaiscUser = new User
                    {
                        FullName = Permission.UserNameBaiscUser.ToLower(),
                        UserName = Permission.UserNameBaiscUser.ToLower(),
                        Email = Permission.EmailBaiscUser.ToLower(),
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };

                    var result = await _userManager.CreateAsync(BaiscUser, Permission.PasswordBaiscUser);
                    if (!result.Succeeded)
                    {
                        Log.Error("error in Create User-- Basic User");
                        new Exception("error in Create User-- Basic User");

                    }
                    //bind role  for BaiscUser
                    await _userManager.AddToRoleAsync(BaiscUser, RolesEnum.Basic.ToString());
                }

            }

            catch (Exception ex)
            {
                Log.Error(ex, "Error Seeding Basic User");
            }
        }
        public static async Task SeedSuperAdminUserAsync(UserManager<User> _userManager, RoleManager<Role> _roleManager, AppDbContext _dbContext)
        {
            try
            {
                var user = await _userManager.FindByEmailAsync(Permission.EmailSuperAdmin);
                if (user == null)
                {
                    var UserSuperAdmin = new User
                    {
                        FullName = Permission.FullNameSuperAdmin.ToLower(),
                        UserName = Permission.UserNameSuperAdmin.ToLower(),
                        Email = Permission.EmailSuperAdmin.ToLower(),
                        EmailConfirmed = true,
                        PhoneNumberConfirmed = true,
                    };
                    //Create UserSuperAdmin
                    var result = await _userManager.CreateAsync(UserSuperAdmin, Permission.PasswordSuperAdmin);

                    if (!result.Succeeded)
                    {
                        new Exception("error in Create User SuperAdmin");
                    }
                    // bind roles  for UserSuperAdmin
                    await _userManager.AddToRolesAsync(UserSuperAdmin, new List<string>
                      { RolesEnum.SuperAdmin.ToString(), RolesEnum.Admin.ToString() , RolesEnum.Basic.ToString() });


                    #region GenerateAllPermission  
                    var modules = Permission.GenerateAllPermission();
                   
                    // usercurrent for  add elements to table Perission by user
                    var usercurrent = await _userManager.FindByNameAsync(Permission.UserNameSuperAdmin);
                    //var claims_by_user = await _userManager.GetClaimsAsync(user);

                    #endregion
                    //roleuperadmin for add elements to table RoleClaim by role
                    var roleuperadmin = await _roleManager.FindByNameAsync(RolesEnum.SuperAdmin.ToString());

                    //add in table Permission & RoleClaims
                    foreach (var item in modules)
                    {
                        //add in table permission
                        await _dbContext.Set<UserPermission>().AddAsync(new UserPermission { UserId = usercurrent.Id, Permission = item });
                        //add table roleCalims
                        await _roleManager.AddClaimAsync(roleuperadmin, new Claim("Permission", item));
                    };

                    await _dbContext.SaveChangesAsync();

                    // #region Permission Generate Role
                    // //role by name
                    // var role = await _roleManager.FindByNameAsync(RolesEnum.SuperAdmin.ToString());
                    //// AllCalims by role
                    //  var AllCalimsByRole = await _roleManager.GetClaimsAsync(role);

                    //// Permission Generate
                    // //var PermissionList = Permission.PermissionList();

                    // //foreach (var PermissionValue in PermissionList)
                    // //{
                    // //    if (!AllCalimsByRole.Any(x => x.Type == CustomClaimTypes.Permission && x.Value == PermissionValue))
                    // //    {
                    // //        await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, PermissionValue));
                    // //    }
                    // //}
                    // #endregion
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Error Seeding superAdmin");

            }

        }
    }
}
