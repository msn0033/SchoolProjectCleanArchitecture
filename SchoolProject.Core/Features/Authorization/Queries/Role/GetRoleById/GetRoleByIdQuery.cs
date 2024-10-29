using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Role.GetRoleById
{
    public class GetRoleByIdQuery : IRequest<ApiResponse<RoleResponse>>
    {
        public int Id { get; set; }
    }
}
