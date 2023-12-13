using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authentication.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    
    [ApiController]
    public class AuthenticationController : AppControllersBase
    {
        [HttpPost(PathRoute.AuthenticationRoute.sigin)]
        public async Task<IActionResult> SignInUser([FromBody]SignInUserCommand request)
        {
            var w = Request.Path;
            var s = PathRoute.AuthenticationRoute.sigin;
            var result =await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
