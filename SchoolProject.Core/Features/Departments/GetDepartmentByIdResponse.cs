using SchoolProject.Core.Base.PaginatedList;
using SchoolProject.Core.Features.Instructors;
using SchoolProject.Core.Features.Students;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments
{
    public class GetDepartmentByIdResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? NameManger { get; set; }
        public PaginatedList<StudentResponse>? StudentList { get; set; }//expression in DeparementsHandlers
        public List<SubjectResponse>? SubjecttList { get; set; }//mapper
        public List<InstructorsDto>? InstructorList { get; set; }//mapper

    }

}
