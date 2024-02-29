//using Microsoft.AspNetCore.Authorization;
//using Microsoft.Extensions.Options;
//using SchoolProject.Data.Permission;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace SchoolProject.Service.Services.Permission_Policy_based_Authorization
//{
//    public class PermissionPolicyProvider : IAuthorizationPolicyProvider
//    {
//        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; }
//        public PermissionPolicyProvider(IOptions<AuthorizationOptions> options)
//        {
//            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
//        }
//        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
//        {
//            return FallbackPolicyProvider.GetDefaultPolicyAsync();
//        }

//        public Task<AuthorizationPolicy?> GetFallbackPolicyAsync()
//        {
//            return FallbackPolicyProvider.GetDefaultPolicyAsync();
//        }

//        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
//        {
//            if(policyName.StartsWith(CustomClaimTypes.Permission,StringComparison.OrdinalIgnoreCase))
//            {
//                var policy = new AuthorizationPolicyBuilder();
//                policy.AddRequirements(new PermissionRequirement(policyName));
//                return Task.FromResult(policy.Build());
//            }
//            return FallbackPolicyProvider.GetPolicyAsync(policyName);
//        }
//    }
//}
