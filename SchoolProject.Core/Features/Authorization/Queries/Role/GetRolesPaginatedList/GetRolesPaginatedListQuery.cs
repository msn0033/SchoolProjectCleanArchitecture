using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Role.GetRolesPaginatedList
{
    public class GetRolesPaginatedListQuery : IRequest<ApiResponse<PaginatedList<RoleResponse>>>
    {
        public int pageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
