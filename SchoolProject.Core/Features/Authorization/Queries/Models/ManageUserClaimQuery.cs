using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Data.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserClaimQuery:IRequest<ApiResponse<ManageUserClaimsResult>>
    {
        public int UserId { get; set; }
    }
}
