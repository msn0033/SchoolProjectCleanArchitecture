
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
        #region Role
        [HttpPost(PathRoute.AuthorizationRoute.Create)]
        public async Task<IActionResult> Create([FromForm]AddRoleCommand request)
        {
        
            var result=await _mediator.Send(request);
            return NewResult(result);
        }
        //====================================================================
       
        [HttpGet(PathRoute.AuthorizationRoute.RolesPaginated)]
        public async Task<IActionResult> GetRolesPaginated([FromQuery] GetRolesPaginatedListQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
        //====================================================================

        [HttpGet(PathRoute.AuthorizationRoute.GetRoleById)]
        public async Task<IActionResult> GetRoleById([FromQuery] GetRoleByIdQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
       
        //====================================================================

        [HttpGet(PathRoute.AuthorizationRoute.GetRoleByName)]
        public async Task<IActionResult> GetRoleByName([FromQuery] GetRoleByNameQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
        
        //====================================================================

        [HttpGet(PathRoute.AuthorizationRoute.Get_Manage_Roles_By_UserId)]
         public async Task<IActionResult> Get_Manage_Roles_By_UserId([FromQuery] ManageUserRolesQuery request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
       
        //====================================================================

        [SwaggerOperation(Summary = "Edit Roles For User ", OperationId = "UpdateManageRolesByUserId")]
        [HttpPut(PathRoute.AuthorizationRoute.Update_Manage_Roles_By_UserId)]
        public async Task<IActionResult> Update_Manage_Roles_By_UserId(UpdateUserRolesCommand command)
        {
           var response=await _mediator.Send(command);
            return NewResult(response);
        }


        #endregion
        //====================================================================

        #region Claims
        //claims
        [SwaggerOperation(Summary= "Manage Claims for User", OperationId= "Manage-Claim-By-UserId")]
        [HttpGet(PathRoute.AuthorizationRoute.Get_Manage_Claims_By_UserId)]
        public async Task<IActionResult> Get_Manage_Claims_By_UserId([FromRoute] int id)
        {
            var response = await _mediator.Send(new ManageUserClaimQuery { UserId=id});
            return NewResult(response);
        }

       
        //====================================================================
        [SwaggerOperation(Summary = "Edit Claims for User ", OperationId = "Update-Claims-by-UserId")]
        [HttpPut(PathRoute.AuthorizationRoute.Update_Manage_Claims_By_UserId)]
        public async Task<IActionResult> Update_Manage_Claims_By_UserId(UpdateUserClaimsCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        //====================================================================
    }

}
