using MediatR;
using SchoolProject.Core.Features.Authorization.Queries.Responses;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Authorization.Queries.Models
{
    public class GetRolesPaginatedListQuery:IRequest<Response<PaginatedResult<GetRolesPaginatedListQueryResponse>>>
    {
        public int pageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
