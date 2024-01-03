using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Data.AppMetaData;
using System.Security.Claims;

namespace SchoolProject.Api.Controllers
{
   // [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : AppControllersBase
    {
        [HttpPost(PathRoute.AuthorizationRoute.Create)]
        public async Task<IActionResult> Create([FromForm]AddRoleCommand request)
        {
        
            var result=await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
