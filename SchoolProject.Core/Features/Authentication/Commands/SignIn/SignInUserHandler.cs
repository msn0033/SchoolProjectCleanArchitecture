using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authentication.Commands.RefreshToken;
using SchoolProject.Core.Features.Authentication.Commands.SignIn;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Service.Base;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class SignInUserHandler : ApiResponseHandler,
        IRequestHandler<SignInUserCommand, ApiResponse<AuthResult>>
 
    {
        private readonly IStringLocalizer<SignInUserHandler> _localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;
   

        public SignInUserHandler( 
            IStringLocalizer<SignInUserHandler> localizer,
            SignInManager<User>signInManager,
            IAuthenticationService authenticationService) :base(localizer) 
        {
            this._localizer = localizer;
            this._signInManager = signInManager;
            this._authenticationService = authenticationService;
        }
        //SignInUser
        public async Task<ApiResponse<AuthResult>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
        
            User? user=(await _signInManager.UserManager.FindByNameAsync(request.UserName!));

            if (user == null)
            {
                return BadRequest<AuthResult>(_localizer[ShareResourcesKey.Incorrect_username_password]);
            }

            var result=await _signInManager.CheckPasswordSignInAsync(user!, request.Password!,false);
            if(!result.Succeeded)
            {
                return BadRequest<AuthResult>(_localizer[ShareResourcesKey.Incorrect_password]);
            }
           
            var accesstoken=await _authenticationService.GetJWTTokenBySignInUserAsync(user!);
          
            return Success(accesstoken);
        }

       
    }
}
