using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
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

        [HttpGet(PathRoute.AuthorizationRoute.RolesPaginated)]
        public async Task<IActionResult> GetRolesPaginated([FromQuery] GetRolesPaginatedListQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }

        [HttpGet(PathRoute.AuthorizationRoute.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromQuery] GetRoleByIdQueryRequest request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
        [HttpGet(PathRoute.AuthorizationRoute.GetRoleByName)]
        public async Task<IActionResult> GetRoleByName([FromQuery] GetRoleByNameQueryRequest request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }

        [HttpGet(PathRoute.AuthorizationRoute.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromQuery] ManageUserRolesQueryRequest request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
    }
}
