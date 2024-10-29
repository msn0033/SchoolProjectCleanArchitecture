using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Role.GetRoleByName
{
    public class GetRoleByNameQuery : IRequest<ApiResponse<RoleResponse>>
    {
        public string? SearchName { get; set; }
    }
}
