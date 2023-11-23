
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Data.AppMetaData;

namespace SchoolProject.Api.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : AppControllersBase
    {
      
        [HttpPost(PathRoute.ApplicationUsersRoute.Create)]
        public async Task<IActionResult> Create([FromBody] AddUserCommand request)
        {
            var result =await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
