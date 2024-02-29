using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.AuthServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.AuthServices.implementations
{
    public class CurrentUserService : ICurrentUserService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<User> _userManager;

        #region field

        #endregion

        #region ctor
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<User> userManager)
        {
            this._httpContextAccessor = httpContextAccessor;
            this._userManager = userManager;
        }

        #endregion

        #region method


        public int UserId()
        {
            var userid = _httpContextAccessor.HttpContext.User.Claims.FirstOrDefault(x => x.Type == nameof(ClaimTypes.NameIdentifier)).Value;
            if (userid == null)
                throw new UnauthorizedAccessException();
            return int.Parse(userid);
        }
        public async Task<User> GetUserAsync()
        {
            var userid = UserId().ToString();
            var user = await _userManager.FindByIdAsync(userid);
            return user!;

        }
        #endregion

    }
}
