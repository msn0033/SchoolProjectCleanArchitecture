
using Microsoft.AspNetCore.Mvc;

using SchoolProject.Api.Base;
using SchoolProject.Core.Features.Authorization.Command.Claim.Update;
using SchoolProject.Core.Features.Authorization.Command.Role.Create;
using SchoolProject.Core.Features.Authorization.Command.Role.Update;
using SchoolProject.Core.Features.Authorization.Queries.Claim;
using SchoolProject.Core.Features.Authorization.Queries.Role.Get_Roles_By_UserId;
using SchoolProject.Core.Features.Authorization.Queries.Role.GetRoleById;
using SchoolProject.Core.Features.Authorization.Queries.Role.GetRoleByName;
using SchoolProject.Core.Features.Authorization.Queries.Role.GetRolesPaginatedList;
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
        public async Task<IActionResult> Create([FromForm]CreateRoleCommand request)
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
         public async Task<IActionResult> Get_Manage_Roles_By_UserId([FromQuery] Get_Manage_Roles_By_UserId_Query request)
        {

            var result = await _mediator.Send(request);
            return NewResult(result);
        }
       
        //====================================================================

        [SwaggerOperation(Summary = "Edit Roles For User ", OperationId = "UpdateManageRolesByUserId")]
        [HttpPut(PathRoute.AuthorizationRoute.Update_Manage_Roles_By_UserId)]
        public async Task<IActionResult> Update_Manage_Roles_By_UserId(UpdateRolesCommand command)
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
            var response = await _mediator.Send(new Get_ManageClaimbyUserIdQuery { UserId=id});
            return NewResult(response);
        }

       
        //====================================================================
        [SwaggerOperation(Summary = "Edit Claims for User ", OperationId = "Update-Claims-by-UserId")]
        [HttpPut(PathRoute.AuthorizationRoute.Update_Manage_Claims_By_UserId)]
        public async Task<IActionResult> Update_Manage_Claims_By_UserId(UpdateClaimsCommand command)
        {
            var response = await _mediator.Send(command);
            return NewResult(response);
        }
        #endregion

        //====================================================================
    }

}
