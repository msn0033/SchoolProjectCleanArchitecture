using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.AppMetaData;
using System.Linq;
using System.Security.Claims;

namespace SchoolProject.Api.Controllers
{
    
    [ApiController]
    public class AuthenticationController : AppControllersBase
    {
        [HttpPost(PathRoute.AuthenticationRoute.sigin)]
        public async Task<IActionResult> SignInUser([FromBody]SignInUserCommand request)
        {
         
            var result =await _mediator.Send(request);
            // HttpContext.Response.Cookies.Append("token", result.Data.AccessToken);
           
            return NewResult(result);
        }
        [HttpPost(PathRoute.AuthenticationRoute.RefreshToken)]
        public async Task<IActionResult> RefreshToken([FromQuery] RefreshTokenCommand request)
        {
           var result=await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
