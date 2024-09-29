using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Views
{
    /*
     
    Create View ViewDepartment
        As
        Select d.Id , d.NameAr ,d.NameEn, count(s.Id) as StudentCount 
        from dbo.Departments d left join dbo.Students s
        on d.Id=s.DepartmentId
        group by d.Id ,d.NameEn , d.NameAr 
     * */

    public class DepartmentStudentCountView: GeneralLocalizableEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }

        public int StudentCount { get; set; }
    }
}
