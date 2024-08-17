using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Enums;
using SchoolProject.Data.Permission;
using SchoolProject.Infrustructure.Context;
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


        public static  async Task SeedSuperAdminUserAsync(UserManager<User> _userManager, RoleManager<Role> _roleManager,AppDbContext _dbContext)
        {
            try
            {
                if (!await _userManager.Users.AnyAsync())
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
                   // bind role  for UserSuperAdmin
                      await _userManager.AddToRoleAsync(UserSuperAdmin, RolesEnum.SuperAdmin.ToString());
                      await _userManager.AddToRoleAsync(UserSuperAdmin, RolesEnum.Admin.ToString());
                      await _userManager.AddToRoleAsync(UserSuperAdmin, RolesEnum.Basic.ToString());

                    #region Permission Generate 

                   
                    List<string> modules=new List<string>();
                    foreach (var module in Enum.GetNames(typeof(ModuleEnum)))
                    {
                        modules.AddRange( Permission.GeneratePermissionsForModule(module));//Create.NameController
                    }
                    
                    var user = await _userManager.FindByNameAsync(Permission.UserNameSuperAdmin);
                    //var claims_by_user = await _userManager.GetClaimsAsync(user);

                   
                   


                    foreach (var item in modules)
                    {
                        await _dbContext.Set<UserPermission>().AddAsync(new UserPermission { UserId = user.Id, Permission = item });
                    };
                   await  _dbContext.SaveChangesAsync();
                   

                    
                 


                    #endregion
                    #region Permission Generate Role
                    //role by name
                    var role = await _roleManager.FindByNameAsync(RolesEnum.SuperAdmin.ToString());
                   // AllCalims by role
                     var AllCalimsByRole = await _roleManager.GetClaimsAsync(role);

                   // Permission Generate
                    //var PermissionList = Permission.PermissionList();

                    //foreach (var PermissionValue in PermissionList)
                    //{
                    //    if (!AllCalimsByRole.Any(x => x.Type == CustomClaimTypes.Permission && x.Value == PermissionValue))
                    //    {
                    //        await _roleManager.AddClaimAsync(role, new Claim(CustomClaimTypes.Permission, PermissionValue));
                    //    }
                    //}
                    #endregion
                }
            }
            catch (Exception ex)
            {

                throw ex.InnerException;
            }

        }
    }
}
