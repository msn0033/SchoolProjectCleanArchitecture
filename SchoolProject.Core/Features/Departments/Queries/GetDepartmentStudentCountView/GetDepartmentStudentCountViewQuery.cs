using MediatR;
using SchoolProject.Core.Base.ApiResponse;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.GetDepartmentStudentCountView
{
    public class GetDepartmentStudentCountViewQuery : IRequest<ApiResponse<List<GetDepartmentStudentCountViewResponse>>>
    {
    }
}
