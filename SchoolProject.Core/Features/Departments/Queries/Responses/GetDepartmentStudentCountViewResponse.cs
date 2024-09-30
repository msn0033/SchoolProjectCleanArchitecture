using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Responses
{
    public class GetDepartmentStudentCountViewResponse
    {
        public string Name { get; set; }
        public int StudentCount { get; set; }
    }
}
