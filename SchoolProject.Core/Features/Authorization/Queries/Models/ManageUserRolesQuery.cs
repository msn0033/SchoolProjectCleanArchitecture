using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Data.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class ManageUserRolesQuery : IRequest<ApiResponse<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
