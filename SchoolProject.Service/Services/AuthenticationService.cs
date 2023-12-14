using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.ModelsHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly JwtSettings _jwtSettings;

        public AuthenticationService( JwtSettings jwtSettings)
        {
            this._jwtSettings = jwtSettings;
        }
        public Task<string> GetJWTToken(User user)
        {
            var Claims = new List<Claim>() 
            {
                new Claim("UserName", user.UserName),
                new Claim(nameof(UserClaimModel.Email), user.Email),
                new Claim(nameof(UserClaimModel.PhoneNumber), user.PhoneNumber),
            };
            var jwtToken=new JwtSecurityToken(_jwtSettings.Issuer,
               audience: _jwtSettings.Audience,
                claims:Claims,
                expires:DateTime.Now.AddDays(90),
                signingCredentials :new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSettings.Secret)),SecurityAlgorithms.HmacSha256Signature));
           
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            var result= Task.FromResult(accessToken);
            return result;
               // return Task.FromResult(accessToken);

        }
    }
}
