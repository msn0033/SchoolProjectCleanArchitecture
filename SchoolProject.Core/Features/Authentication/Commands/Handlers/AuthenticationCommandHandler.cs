using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Helper.Resources;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authentication.Commands.Handlers
{
    public class AuthenticationCommandHandler : ResponseHandler,
        IRequestHandler<SignInUserCommand, Response<string>>
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
        public async Task<Response<string>> Handle(SignInUserCommand request, CancellationToken cancellationToken)
        {
        
            var user=await _signInManager.UserManager.FindByNameAsync(request.UserName);
           
            //if(user == null)
            //    return BadRequest<string>(_localizer[ShareResourcesKey.Incorrect_password]);
            var result=await _signInManager.CheckPasswordSignInAsync(user, request.Password,false);
            if(!result.Succeeded)
            {
                return BadRequest<string>(_localizer[ShareResourcesKey.Incorrect_password]);
            }
            var accesstoken=await _authenticationService.GetJWTToken(user);
            return Success(accesstoken);
        }
    }
}
