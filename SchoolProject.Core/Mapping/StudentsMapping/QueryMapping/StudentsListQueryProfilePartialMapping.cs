using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile
    {
        public void GetStudentListMapping()
        {
            CreateMap<Student, StudentsListQueryResponse>()
               .ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Name));
        }
    }
}
