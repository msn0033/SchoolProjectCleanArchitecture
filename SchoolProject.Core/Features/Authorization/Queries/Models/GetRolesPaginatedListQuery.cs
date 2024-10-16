using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRolesPaginatedListQuery:IRequest<ApiResponse<PaginatedList<GetRolesPaginatedListQueryResponse>>>
    {
        public int pageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
