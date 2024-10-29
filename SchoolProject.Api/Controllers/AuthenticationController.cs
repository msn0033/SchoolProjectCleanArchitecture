using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SchoolProject.Api.Base;
using SchoolProject.Data.AppMetaData;
using System.Linq;
using System.Security.Claims;
using SchoolProject.Core.Features.Authentication.Commands.SignIn;
using SchoolProject.Core.Features.Authentication.Commands.RefreshToken;

namespace SchoolProject.Api.Controllers
{

    [ApiController]
    public class AuthenticationController : AppControllersBase
    {
        [HttpPost(PathRoute.AuthenticationRoute.sigin)]
        public async Task<IActionResult> SignInUser([FromBody] SignInUserCommand request)
        {

            var result = await _mediator.Send(request);
            if (result?.Data?.Token != null)
            {
                HttpContext
                    .Response
                    .Cookies
                    .Append("token", result.Data.Token, new CookieOptions { HttpOnly = true });
            }
            return NewResult(result!);
        }
       
        [HttpPost(PathRoute.AuthenticationRoute.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromQuery] RefreshTokenCommand request)
        {
            var result = await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
