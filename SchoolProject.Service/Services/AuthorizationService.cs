
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
        private readonly AppDbContext _appDbContext;

        public AuthorizationService(RoleManager<Role> roleManager,AppDbContext appDbContext)
        {
            this._roleManager = roleManager;
            this._appDbContext = appDbContext ;
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

        public async Task<bool> IsExistRoleAsync(string search)
        {
          

            var result = await _appDbContext.Roles
                .FirstOrDefaultAsync(x => x.NameEn.Contains(search) || x.NameAr.Contains(search));
            if (result != null)
                return true;
            return false;
        }
    }
}
