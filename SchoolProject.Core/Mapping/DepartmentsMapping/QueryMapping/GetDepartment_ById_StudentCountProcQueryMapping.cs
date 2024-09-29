using SchoolProject.Core.Features.Departments.Queries.Models;
using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace SchoolProject.Core.Mapping.DepartmentsMapping
    {
        public partial class DepartmentsProfile
        {
            public void GetDepartment_ById_StudentCountProcQueryMapping()
            {
            CreateMap<GetDepartment_ById_StudentCountProcQuery, DepartmentStudentCountProcParamater>();
            // .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepartmentId));

            //==================================================================================//
            CreateMap<DepartmentStudentCountProc, GetDepartment_ById_StudentCountProcResponse>()
             .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localize(src.NameAr, src.NameEn)))
             .ForMember(des=>des.StudentCount,opt=>opt.MapFrom(src=>src.StudentCount));
        

            }
    }
}
