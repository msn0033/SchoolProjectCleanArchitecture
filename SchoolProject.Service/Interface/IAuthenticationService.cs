using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Result;
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
        Task<JwtAuthResult> GetJWTTokenBySignInUserAsync(User user);
        Task<JwtAuthResult> GetRefreshTokenAsync(User user,UserRefreshToken? userRefreshToken);
        (JwtSecurityToken?,string) ReadJWTToken(string accesstoken);
        (string,bool) ValidateToken(string accesstoken);

        Task<(string, User?, UserRefreshToken?)> ValidateDeatails(JwtSecurityToken ReadjwtSecurityToken, string accessToken, string refreshTokenString);
    }
}
