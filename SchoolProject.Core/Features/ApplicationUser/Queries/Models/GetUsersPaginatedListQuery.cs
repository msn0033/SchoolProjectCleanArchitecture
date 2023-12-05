using MediatR;
using SchoolProject.Core.Features.ApplicationUser.Queries.Responses;
using SchoolProject.Helper.ResponseHelper;
using SchoolProject.Helper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.ApplicationUser.Queries.Models
{
    public class GetUsersPaginatedListQuery:IRequest<Response<PaginatedResult<GetUsersPaginatedListResponse>>>
    {
        public int pageSize { get; set; }
        public int pageNumber { get; set; }
    }
}
