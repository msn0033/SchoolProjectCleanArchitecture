﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.ModelsHelper;
using SchoolProject.Data.Result;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Migrations;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace SchoolProject.Service.Services
{
    public class AuthenticationService : IAuthenticationService
    {

        #region field
        private readonly Jwtsettings _jwtsettings;
        private readonly IRefreshTokenRepository _refreshTokenRepository;
        private readonly UserManager<User> _userManager;
        #endregion

        #region ctor
            public AuthenticationService(Jwtsettings jwtsettings
           , IRefreshTokenRepository refreshTokenRepository
           , UserManager<User> userManager)
            {
                this._jwtsettings = jwtsettings;
                _refreshTokenRepository = refreshTokenRepository;
                this._userManager = userManager;
            }

        #endregion

        #region method


        public async Task<JwtAuthResult> GetJWTTokenBySignInUserAsync(User user)
        {
            if (user == null)
            {
                JwtAuthResult jwtAuthResponse_ = new JwtAuthResult();
                jwtAuthResponse_.message = "user is not found";
                return jwtAuthResponse_;
            }
            var (accessToken, jwtSecurityToken) = await GenerateAccessTokenAsync(user);
            var refreshtoken = GetRandomRefreshToken(user);

            var usertoken = new UserRefreshToken
            {
                AccessToken = accessToken,
                RefreshTokenString = refreshtoken.RefreshTokenString,
                AddTime = DateTime.Now,
                ExpireAt = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpire),
                UserId = user?.Id,
                IsActive = true,
                IsRevoked = false,
               
                Id = _refreshTokenRepository.GetTableNoTracking().Count() + 1
            };

            var userrefreshtoken = await _refreshTokenRepository
                .GetTableAsTracking()
                .FirstOrDefaultAsync(x => x.UserId == usertoken.UserId);
            if (userrefreshtoken == null)
            {
                await _refreshTokenRepository.AddAsync(usertoken);
            }
            else
            {

                userrefreshtoken.AccessToken = usertoken.AccessToken;
                userrefreshtoken.RefreshTokenString = usertoken.RefreshTokenString;
                userrefreshtoken.UserId = usertoken.UserId;
                userrefreshtoken.ExpireAt = usertoken.ExpireAt;
                userrefreshtoken.IsActive = usertoken.IsActive;
                userrefreshtoken.IsRevoked = usertoken.IsRevoked;
                userrefreshtoken.JwtSecurityTokenId = usertoken.JwtSecurityTokenId;
                userrefreshtoken.AddTime = usertoken.AddTime;

                await _refreshTokenRepository.UpdateAsync(userrefreshtoken);
            }

            JwtAuthResult jwtAuthResponse = new JwtAuthResult();
            jwtAuthResponse.AccessToken = accessToken;
            jwtAuthResponse.RefreshToken = refreshtoken;
            return jwtAuthResponse;

        }
        //
        #region private
        private async Task<List<Claim>> Get_Claims_Role_Async(User user)
        {
            //Create  claims
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName!),
                new Claim(ClaimTypes.Email,user.Email!),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString()),
               
               
            };
            //add cliams by user to new claims
            var claimuser = await _userManager.GetClaimsAsync(user);
            
            claims.AddRange(claimuser);

            //get Roles by user
            var roles = await _userManager.GetRolesAsync(user);

            //role add new claims
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            return claims;
        }
        private async Task<(string, JwtSecurityToken)> GenerateAccessTokenAsync(User user)
        {
            var claims = await Get_Claims_Role_Async(user);

            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings?.Secret!));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature);

            //var tokenDescriptor = new SecurityTokenDescriptor
            //{
            //    Issuer = _jwtsettings?.Issuer,
            //    Audience = _jwtsettings?.Audience,
            //    Subject = new ClaimsIdentity(claims),
            //    Expires = DateTime.UtcNow.AddDays(_jwtsettings!.AccessTokenExpire),
            //    SigningCredentials = signIn,
            //};
            //var tokenHandler = new JwtSecurityTokenHandler();
            //var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            //var accessToken = tokenHandler.WriteToken(securityToken);

            //return (accessToken, tokenDescriptor);
            //==========or====================

            var jwtSecurityToken = new JwtSecurityToken(issuer: _jwtsettings?.Issuer,
                                      audience: _jwtsettings?.Audience,
                                       claims: claims,
                                       expires: DateTime.UtcNow.AddDays(_jwtsettings!.AccessTokenExpire),
                                       signingCredentials: signIn);

            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);

            return (accessToken, jwtSecurityToken);

            // return Task.FromResult(accessToken);
        }
        private static string GetRandomNumberGenerate()
        {
            var randomNumber = new byte[32];
            var randomNumberGenerate = RandomNumberGenerator.Create();
            randomNumberGenerate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        private RefreshToken GetRandomRefreshToken(User? user)
        {
            // var userRefreshToken = new ConcurrentDictionary<string, RefreshToken>();
            var refreshtoken = new RefreshToken
            {
                UserName = user?.UserName,
                RefreshTokenString = GetRandomNumberGenerate(),
                ExpaireAt = DateTime.Now.AddDays(_jwtsettings.RefreshTokenExpire)

            };

            //var x=userRefreshToken.
            //    AddOrUpdate(refreshtoken.TokenString, refreshtoken,
            //                (s, r) => refreshtoken);
            return refreshtoken;
        }
        #endregion
        //
        public (JwtSecurityToken?, string) ReadJWTToken(string accesstoken)
        {
            var (message, condition) = ValidateToken(accesstoken);
            if (condition)
            { //decode accesstoken
                var handler = new JwtSecurityTokenHandler();
                var jwtSecurityToken = handler.ReadJwtToken(accesstoken);
                return (jwtSecurityToken, message);
            }
            return (null, message);
        }

        public async Task<(string, User?, UserRefreshToken?)> ValidateDeatails(JwtSecurityToken ReadjwtSecurityToken, string accessToken, string refreshTokenString)
        {

            if (ReadjwtSecurityToken == null || !ReadjwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256Signature))
            {
                return ("Algorithm is Wrong", null, null);
            }

            if (ReadjwtSecurityToken.ValidTo > DateTime.UtcNow)
            {
                return ("Token is not Expire", null, null);
            }
            string? userId = ReadjwtSecurityToken?.Claims?.FirstOrDefault(x => x.Type == nameof(UserClaimModel.UserId))?.Value;
            if (userId == null)
            {
                return ("UserId is null", null, null);
            }

            var userRefreshToken = await _refreshTokenRepository
                .GetTableNoTracking()
                .FirstOrDefaultAsync(x => x.AccessToken == accessToken
                       && x.RefreshTokenString == refreshTokenString
                       && x.UserId == int.Parse(userId));

            if (userRefreshToken == null)
            {
                return ("UserRefreshToken Not Found", null, null);
            }
            if (userRefreshToken.ExpireAt < DateTime.UtcNow)//userRefreshToken is Expire
            {
                userRefreshToken.IsRevoked = true;
                userRefreshToken.IsActive = false;
                await _refreshTokenRepository.UpdateAsync(userRefreshToken);
                return ("Refresh Token is Expire", null, null);
            }

            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return ("User is not Found", null, null);
            }

            return ("success", user, userRefreshToken);
        }

       
        public (string, bool) ValidateToken(string accesstoken)
        {
            //validator token
            var paramaters = new TokenValidationParameters
            {
                ValidateIssuer = _jwtsettings.ValidateIssure,
                ValidateAudience = _jwtsettings.ValidateAudience,
                ValidateLifetime = _jwtsettings.ValidateLifetime,
                ValidateIssuerSigningKey = _jwtsettings.ValidateIssuerSigningKey,
                ValidIssuer = _jwtsettings.Issuer,
                ValidAudience = _jwtsettings.Audience,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtsettings?.Secret!))
            };
            try
            {
                var handler = new JwtSecurityTokenHandler();
                var validator = handler.ValidateToken(accesstoken, paramaters, out SecurityToken validateToken);

                if (validator == null)
                {
                    return ("ValidateToken is false", false);
                }
                return ("ValidateToken is true", true);

            }
            catch (Exception ex)
            {

                return ($"Invalid Token TokenValidationParameters + {ex.Message + ex?.InnerException?.Message}", false);
            }
        }
        
        public async Task<JwtAuthResult> GetRefreshTokenAsync(User user, UserRefreshToken? userRefreshToken)
        {
            var (NewAccessToken, jwtsecurityToken) = await GenerateAccessTokenAsync(user);


            if (user == null)
            {
                return new JwtAuthResult { message = "user is null" };
            }
            if (userRefreshToken == null)
            {
                return new JwtAuthResult { message = "userRefreshToken is null" };
            }

            userRefreshToken.AccessToken = NewAccessToken;
            await _refreshTokenRepository.UpdateAsync(userRefreshToken);

            var refreshtoken = new RefreshToken
            {
                RefreshTokenString = userRefreshToken.RefreshTokenString,
                UserName = jwtsecurityToken?.Claims?.FirstOrDefault(x =>x.Type == nameof(UserClaimModel.UserName))?.Value,
                ExpaireAt = userRefreshToken.ExpireAt
            };
            var response = new JwtAuthResult
            {
                AccessToken = NewAccessToken,
                RefreshToken = refreshtoken,
                message = "success"
            };
            return response;
        }

        #endregion
    }
}

