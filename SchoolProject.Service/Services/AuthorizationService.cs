
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.ModelsHelper;
using SchoolProject.Data.Request;
using SchoolProject.Data.Result;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Services
{
    public class AuthorizationService : IAuthorizationService
    {
        private readonly RoleManager<Role> _roleManager;
        private readonly UserManager<User> _userManager;
        private readonly AppDbContext _dbContext;

        public AuthorizationService(RoleManager<Role> roleManager
            , UserManager<User> userManager
            , AppDbContext dbContext)
        {
            this._roleManager = roleManager;
            this._userManager = userManager;
            this._dbContext = dbContext;
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
        public async Task<ManageUserRolesResult> GetManageRolesByUserIdAsync(User user)
        {
            var respons = new ManageUserRolesResult();
            var newroleslist = new List<UserRoles>();
            //roles
            //var roles = await GetAllRolesAsync();
            var roles =await _roleManager.Roles.ToListAsync();
            foreach (var role in roles)
            {
                if (role.Name != null)
                {
                    var userrole = new UserRoles();
                    userrole.Id = role.Id;
                    userrole.Name = role.Name;
                    var check = await _userManager.IsInRoleAsync(user, role.Name.ToString());
                    if (check)
                    {
                        userrole.IsSelected = true;
                    }
                    else
                        userrole.IsSelected = false;

                    newroleslist.Add(userrole);
                }
            }
            respons.UserId = user.Id;
            respons.UserRoles = newroleslist;

            return respons;

        }
        public async Task<string> UpdateManageRolesByUserIdAsync(UpdateUserRolesRequest request)
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
            var newRoles = request.UserRoles?.Where(x => x.IsSelected).Select(x => x.Name);
            var result = await _userManager.AddToRolesAsync(user, newRoles!);
            if (!result.Succeeded)
            {
                return "error on add new Roles";
            }
            return "Success";
        }

        //Get all claims and selected on claims by user
        //manage claims
        public async Task<ManageUserClaimsResult> GetManageUserClaimsDataAsync(User user)
        {
            var response = new ManageUserClaimsResult();
            var ListNewuserClaims = new List<UserClaim>();
            //Get Claims by user
            var Claims = await _userManager.GetClaimsAsync(user);// edit
            if (Claims.Count ==0)
                return null ;


            foreach (var item in ClaimsStore.Claims)//Create Edti Delete Details
            {
                var userclaim = new UserClaim();
                userclaim.Type = item.Type;
                if (Claims.Any(x => x.Type == item.Type))
                {
                    userclaim.Value = true;
                }
                else
                {
                    userclaim.Value = false;
                }
                ListNewuserClaims.Add(userclaim);
            }
            response.UserId = user.Id;
            response.UserClaims = ListNewuserClaims;
            return response;
        }

        //update claims
        public async Task<string> UpdateUserClaimsAsync(UpdateUserClaimsRequest request)
        {
            var transaction = _dbContext.Database.BeginTransaction();
            try
            {
                var user = await _userManager.FindByIdAsync(request.UserId.ToString());
                if (user == null)
                    return "UserIsNull";
                var userclaims = await _userManager.GetClaimsAsync(user);
                var removeClaims = await _userManager.RemoveClaimsAsync(user, userclaims);

                if (!removeClaims.Succeeded)
                    return "FailedToRemoveOldClaimsByUser";

                var AddnewUserClaims = request.UserClaims
                    .Where(x => x.Value == true)
                    .Select(x => new Claim(x.Type, x.Value.ToString()));

                var result = await _userManager.AddClaimsAsync(user, AddnewUserClaims);
                if (!result.Succeeded)
                    return "FailedToAddNewClaims";

                await transaction.CommitAsync();
                return "Success";
            }
            catch (Exception ex)
            {
                transaction.Rollback();
                return $"FailedToUpdateClaims => exception :{ex.Message}";

            }

        }
    }
}
