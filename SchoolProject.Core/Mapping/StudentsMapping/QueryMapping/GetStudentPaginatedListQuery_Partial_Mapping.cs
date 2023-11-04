using SchoolProject.Core.Features.Students.Queries.Responses;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SchoolProject.Core.Mapping.StudentsMapping
{
    public partial class StudentProfile
    {
        public void GetStudentPaginatedListQuery_Partial_Mapping()
        {
            CreateMap<Student, GetStudentPaginatedListResponse>()
               .ForMember(des => des.DepartmentName, op => op.MapFrom(src => src.Department.Localize(src.NameAr, src.NameEn)))
               .ForMember(des => des.Name, op => op.MapFrom(src => src.Localize(src.NameAr, src.NameEn)));
          
        }
    }
}

