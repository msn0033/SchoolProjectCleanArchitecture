using AutoMapper;
using SchoolProject.Core.Features.Departments.Queries.GetById_By_StudentCountProc;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Features.Departments
{
    public class DepartmentsMapping: Profile
    {
        public DepartmentsMapping()
        {
            CreateMap<Department, GetDepartmentByIdResponse>()
               .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
               .ForMember(des => des.NameManger, opt => opt.MapFrom(src => src.InstructorManager!.Localize(src.InstructorManager.NameAr, src.InstructorManager.NameEn)))
               //.ForMember(des => des.StudentList, opt => opt.MapFrom(src => src.Students))
               .ForMember(des => des.InstructorList, opt => opt.MapFrom(src => src.Instructors))
               .ForMember(des => des.SubjecttList, opt => opt.MapFrom(src => src.DepartmentSubjects));

          


            CreateMap<DepartmetSubject, SubjectResponse>()
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.Subjects.Id))
                .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Subjects.Localize(src.Subjects.NameAr, src.Subjects.NameEn)));


            CreateMap<GetDepartment_ById_StudentCountProcQuery, DepartmentStudentCountProcParamater>();
            // .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            //==================================================================================//
            CreateMap<DepartmentStudentCountProc, GetDepartment_ById_StudentCountProcResponse>()
             .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
             .ForMember(des => des.StudentCount, opt => opt.MapFrom(src => src.StudentCount));



            CreateMap<DepartmentStudentCountView, GetDepartmentStudentCountViewResponse>()
                .ForMember(des => des.Name, opt => opt.MapFrom(sour => sour.Localize(sour.NameAr, sour.NameEn)))
                .ForMember(des => des.StudentCount, opt => opt.MapFrom(sour => sour.StudentCount));
        }
    }
}
