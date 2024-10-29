using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Base.PaginatedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.GetUsersPaginatedList
{
    public class GetUsersPaginatedListQuery : IRequest<ApiResponse<PaginatedList<GetUsersPaginatedListResponse>>>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
