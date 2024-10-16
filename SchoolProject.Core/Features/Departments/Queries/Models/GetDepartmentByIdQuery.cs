using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentByIdQuery:IRequest<ApiResponse<GetDepartmentByIdResponse>>
    {
        public int Id { get; set; }
        public int PageSize { get; set; }
        public int PageNumber { get; set; }
      
        
    }
}
