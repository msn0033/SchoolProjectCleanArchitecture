using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.DepartmentsMapping
{
    public partial class DepartmentsProfile
    {
        public void DepartmentsDetailsQueryMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
                .ForMember(des => des.NameManger, opt => opt.MapFrom(src => src.InstructorManager!.Localize(src.InstructorManager.NameAr, src.InstructorManager.NameEn)))
                .ForMember(des => des.StudentList, opt => opt.MapFrom(src => src.Students))
                .ForMember(des => des.InstructorList, opt => opt.MapFrom(src => src.Instructors))
                .ForMember(des => des.SubjecttList, opt => opt.MapFrom(src => src.DepartmentSubjects));

            CreateMap<Instructor, InstructorResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<Student, StudentResponse>()
               .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Id))
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));

            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src =>src.Subjects.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Subjects.Localize(src.Subjects.NameAr, src.Subjects.NameEn)));
        }
    }
}
