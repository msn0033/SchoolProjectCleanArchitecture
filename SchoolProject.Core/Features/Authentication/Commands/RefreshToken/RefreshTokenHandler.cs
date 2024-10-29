using LocalizationLanguage;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using SchoolProject.Core.Base.ApiResponse;
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

namespace SchoolProject.Core.Features.Authentication.Commands.RefreshToken
{
    public class RefreshTokenHandler : ApiResponseHandler,
        IRequestHandler<RefreshTokenCommand, ApiResponse<AuthResult>>
    {
        private readonly IStringLocalizer<RefreshTokenHandler> _localizer;
        private readonly SignInManager<User> _signInManager;
        private readonly IAuthenticationService _authenticationService;


        public RefreshTokenHandler(
            IStringLocalizer<RefreshTokenHandler> localizer,
            SignInManager<User> signInManager,
            IAuthenticationService authenticationService) : base(localizer)
        {
            _localizer = localizer;
            _signInManager = signInManager;
            _authenticationService = authenticationService;
        }
        
        //RefreshToken
        public async Task<ApiResponse<AuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {

            //var v1 = new Claim("aa", "bb");
            //var lis = new List<Claim>();
            //lis.Add(v1);
            //var v2 = new ClaimsIdentity(lis);
            //var v3 = new ClaimsPrincipal(v2);

            var (ReadjwtSecurityToken, messageReadtoken) = _authenticationService.ReadJWTToken(request.Token);
            if (ReadjwtSecurityToken == null)
                return Unauthorized<AuthResult>("Read Token is Null : " + messageReadtoken);

            var (message, user, userRefreshToken) = await _authenticationService.ValidateDeatails(ReadjwtSecurityToken, request.Token, request.RefreshTokenString);

            if (message == "success")
            {
                AuthResult response = await _authenticationService.GetRefreshTokenAsync(user!, userRefreshToken);
                if (response.Message == "success")
                    return Success(response);
                else
                    return Unauthorized<AuthResult>(response?.Message!);
            }
            return Unauthorized<AuthResult>(message);


        }
    }
}
