using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Service.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Role.Get_Roles_By_UserId
{
    public class Get_Manage_Roles_By_UserId_Query : IRequest<ApiResponse<ManageUserRolesResult>>
    {
        public int UserId { get; set; }
    }
}
