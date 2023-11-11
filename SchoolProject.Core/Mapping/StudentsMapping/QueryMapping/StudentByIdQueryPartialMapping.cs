using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;

namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile
    {
        public void GetStudentByIdQueryPartialMapping()
        {
            CreateMap<Student, GetStudentByIdQueryResponse>()
               .ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Localize(src.NameAr, src.NameEn)))
               .ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

        }
    }
}
