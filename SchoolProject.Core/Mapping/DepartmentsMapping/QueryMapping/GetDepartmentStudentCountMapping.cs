using SchoolProject.Core.Features.Departments.Queries.Responses;
using SchoolProject.Data.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Core.Mapping.DepartmentsMapping
{
    public partial class DepartmentsProfile
    {
        public void GetDepartmentStudentCountMapping()
        {

            CreateMap<DepartmentStudentCountView,GetDepartmentStudentCountViewResponse>()
                .ForMember(des=>des.Name,opt=>opt.MapFrom(sour=>sour.Localize(sour.NameAr,sour.NameEn)))
                .ForMember(des=>des.StudentCount,opt=>opt.MapFrom(sour=>sour.StudentCount));
            
        }
    }
}
