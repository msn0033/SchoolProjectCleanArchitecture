using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Infrustructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Filters
{
    public class PermissionBasedAuthorizationFilter(AppDbContext appDbContext) : IAuthorizationFilter
    {
      

        public void OnAuthorization(AuthorizationFilterContext context)
        {

            var ss = context.ActionDescriptor.EndpointMetadata;
            var attribute =(CheckPermissionAttribute)context.ActionDescriptor.EndpointMetadata
                .FirstOrDefault(x => x is CheckPermissionAttribute)!;
            if(attribute != null)
            {
                var claimIdentity = context.HttpContext.User.Identity as ClaimsIdentity;
                if (claimIdentity == null || !claimIdentity.IsAuthenticated)
                {
                    context.Result = new ObjectResult("Not Authenticated pls SignIn  ") { StatusCode=StatusCodes.Status401Unauthorized};
                }
                else
                {
                var userId =int.Parse( claimIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    var hasPermission = appDbContext.Set<UserPermission>()
                        .Any(x => x.UserId == userId && x.Permission == attribute.Permission);
                    if (!hasPermission)
                    {
                       // context.Result = new ForbidResult();
                        context.Result = new ObjectResult($"Not Authorization not hasPermission {attribute.Permission}") { StatusCode = StatusCodes.Status403Forbidden };

                    }

                }
            }
        }
    }
}
