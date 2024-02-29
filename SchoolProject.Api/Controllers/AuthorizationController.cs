
using Microsoft.AspNetCore.Mvc;

using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Models;
using SchoolProject.Core.Features.Authorization.Queries.Models;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Data.AppMetaData;
using Swashbuckle.AspNetCore.Annotations;
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
        public async Task<IActionResult> GetRoleById([FromQuery] GetRoleByIdQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
        [HttpGet(PathRoute.AuthorizationRoute.GetRoleByName)]
        public async Task<IActionResult> GetRoleByName([FromQuery] GetRoleByNameQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }

        [HttpGet(PathRoute.AuthorizationRoute.ManageUserRoles)]
         public async Task<IActionResult> ManageUserRoles([FromQuery] ManageUserRolesQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
        
        [SwaggerOperation(Summary = "تعديل  صلاحيات المستخدم ", OperationId = "UpdateUserRoles")]
        [HttpPut(PathRoute.AuthorizationRoute.UpdateUserRoles)]
        public async Task<IActionResult> UpdateUserRoles(UpdateUserRolesCommand command)
        {
           var response=await _mediator.Send(command);
            return NewResult(response);
        }

        //claims
        [SwaggerOperation(Summary="ادارة صلاحيات المستخدم Claims",OperationId= "ManageUserClaims")]
        [HttpGet(PathRoute.AuthorizationRoute.ManageUserClaims)]
        public async Task<IActionResult> ManageUserClaims([FromRoute] int id)
        {
            var response = await _mediator.Send(new ManageUserClaimQuery { UserId=id});
            return NewResult(response);
        }

        [SwaggerOperation(Summary = "تعديل  صلاحيات Calims ", OperationId = "UpdateUserRoles")]
        [HttpPut(PathRoute.AuthorizationRoute.UpdateUserClaims)]
        public async Task<IActionResult> UpdateUserClaims(UpdateUserClaimsCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
    }
}
