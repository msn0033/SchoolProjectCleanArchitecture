using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Claim
{
    public class Get_ManageClaimbyUserIdQuery : IRequest<ApiResponse<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
