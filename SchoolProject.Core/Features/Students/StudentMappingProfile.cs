using AutoMapper;
using SchoolProject.Core.Features.Students.Commands.Create;
using SchoolProject.Core.Features.Students.Commands.Update;
using SchoolProject.Core.Features.Students.Queries;
using SchoolProject.Data.Entities;


namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public  class StudentMappingProfile : Profile
    {
        public StudentMappingProfile()
        {
            // UpdateStudentCommand to Student
            CreateMap<CreateStudentCommand, Student>();
            // Entity to DTO
            CreateMap<Student, StudentResponse>()
              .ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Localize(src.NameAr, src.NameEn)))
              .ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
        }
 
    }
}
