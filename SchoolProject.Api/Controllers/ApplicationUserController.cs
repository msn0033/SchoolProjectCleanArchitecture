
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.ApplicationUser.Commands.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Models;
using SchoolProject.Core.Features.ApplicationUser.Queries.Responses;
using SchoolProject.Data.AppMetaData;
using SchoolProject.Helper.Wrappers;

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
        [HttpGet(PathRoute.ApplicationUsersRoute.Paginated)]
        public async Task<IActionResult> GetUsersPaginatedList([FromQuery]GetUsersPaginatedListQuery query)
        {
            var result=await _mediator.Send(query);
            return NewResult(result);
        }
    }
}
