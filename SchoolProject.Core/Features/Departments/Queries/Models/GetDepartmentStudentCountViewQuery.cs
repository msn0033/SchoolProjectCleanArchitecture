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
    public class GetDepartmentStudentCountViewQuery:IRequest<ApiResponse<List<GetDepartmentStudentCountViewResponse>>>
    {
    }
}
