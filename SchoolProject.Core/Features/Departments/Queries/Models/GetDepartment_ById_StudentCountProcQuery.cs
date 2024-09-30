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
    public class GetDepartment_ById_StudentCountProcQuery:IRequest<Response<GetDepartment_ById_StudentCountProcResponse>>
    {
        public int DepartmentId { get; set; }
    }
}
