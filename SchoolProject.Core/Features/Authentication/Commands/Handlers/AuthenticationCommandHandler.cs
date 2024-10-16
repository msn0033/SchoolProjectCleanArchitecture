using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Result;

using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ApiResponseHandler,
        IRequestHandler<SignInUserCommand, ApiResponse<JwtAuthResult>>,
        IRequestHandler<RefreshTokenCommand, ApiResponse<JwtAuthResult>>
    {
        private readonly IStringLocalizer<AuthenticationCommandHandler> _localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
   

        public AuthenticationCommandHandler( 
            IStringLocalizer<AuthenticationCommandHandler> localizer,
            SignInManager<User>signInManager,
            IAuthenticationService authenticationService) :base(localizer) 
        {
            this._localizer = localizer;
            this._signInManager = signInManager;
            this._authenticationService = authenticationService;
        }
        //SignInUser
        public async Task<ApiResponse<JwtAuthResult>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
        
            User? user=(await _signInManager.UserManager.FindByNameAsync(request.UserName!));

            if (user == null)
            {
                return BadRequest<JwtAuthResult>(_localizer[ShareResourcesKey.Incorrect_username_password]);
            }

            var result=await _signInManager.CheckPasswordSignInAsync(user!, request.Password!,false);
            if(!result.Succeeded)
            {
                return BadRequest<JwtAuthResult>(_localizer[ShareResourcesKey.Incorrect_password]);
            }
           
            var accesstoken=await _authenticationService.GetJWTTokenBySignInUserAsync(user!);
          
            return Success(accesstoken);
        }

        //RefreshToken
        public async Task<ApiResponse<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {

            //var v1 = new Claim("aa", "bb");
            //var lis = new List<Claim>();
            //lis.Add(v1);
            //var v2 = new ClaimsIdentity(lis);
            //var v3 = new ClaimsPrincipal(v2);
           
            var (ReadjwtSecurityToken,messageReadtoken) = _authenticationService.ReadJWTToken(request.AccessToken);
            if (ReadjwtSecurityToken == null) 
                return Unauthorized<JwtAuthResult>("Read Token is Null : " + messageReadtoken);

            var (message,user,userRefreshToken) = await _authenticationService.ValidateDeatails(ReadjwtSecurityToken, request.AccessToken, request.RefreshTokenString);

            if(message== "success")
            {
                JwtAuthResult response = await _authenticationService.GetRefreshTokenAsync(user!,userRefreshToken);
                if (response.message == "success")
                    return Success(response);
                else 
                    return Unauthorized<JwtAuthResult>(response?.message!);
            }
            return Unauthorized<JwtAuthResult>(message);

            
        }
    }
}
