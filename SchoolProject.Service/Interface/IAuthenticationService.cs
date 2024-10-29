using SchoolProject.Data.Entities.Identity;

using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IAuthenticationService
    {
        Task<AuthResult> GetJWTTokenBySignInUserAsync(User user);
        Task<AuthResult> GetRefreshTokenAsync(User user,UserRefreshToken? userRefreshToken);
        (JwtSecurityToken?,string) ReadJWTToken(string accesstoken);
        (string,bool) ValidateToken(string accesstoken);

        Task<(string, User?, UserRefreshToken?)> ValidateDeatails(JwtSecurityToken ReadjwtSecurityToken, string accessToken, string refreshTokenString);
    }
}
