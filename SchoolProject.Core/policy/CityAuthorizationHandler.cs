using Microsoft.AspNetCore.Authorization;
using SchoolProject.Infrustructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.policy
{
    public class CityAuthorizationHandler : AuthorizationHandler<CityFromJeddahRequirement>
    {
        private readonly AppDbContext _dbContext;

        public CityAuthorizationHandler(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, CityFromJeddahRequirement requirement)
        {
            var city = _dbContext.Users.FirstOrDefault(x => x.City == requirement.city);
            if (city != null) {
                 context.Succeed(requirement);
            }
            return Task.CompletedTask;
          
        }
    }
}
