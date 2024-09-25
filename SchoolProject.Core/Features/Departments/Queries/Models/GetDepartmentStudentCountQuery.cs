using MediatR;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Helper.ResponseHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Models
{
    public class GetDepartmentStudentCountQuery:IRequest<Response<List<GetDepartmentStudentCountResponse>>>
    {
    }
}
