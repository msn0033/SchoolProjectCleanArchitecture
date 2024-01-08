using SchoolProject.Data.Entities;
using SchoolProject.Helper.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments.Queries.Responses
{
    public class GetDepartmentByIdResponse
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public string? NameManger { get; set; }
        public PaginatedResult<StudentResponse>? StudentList { get; set; }//expression in DeparementsHandlers
        public List<SubjectResponse> ?SubjecttList { get; set; }//mapper
        public List<InstructorResponse> ?InstructorList { get; set; }//mapper

    }

    public class StudentResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public StudentResponse(Student e)
        {
            Id= e.Id;
            Name = e.Localize(e.NameAr, e.NameEn);
            
        }
    }
    public class SubjectResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class InstructorResponse
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }

}
