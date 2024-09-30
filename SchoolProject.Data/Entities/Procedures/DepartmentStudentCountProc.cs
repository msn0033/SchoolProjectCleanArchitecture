using SchoolProject.Data.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Data.Entities.Procedures
{

    /*
     Create proc DepartmentStudentCountProc
        @DepartmentId int
        as
        begin
        Create table #temp (Id int ,NameAr nvarchar(50),NameEn nvarchar(50),StudentCount int)
        insert into #temp
        select d.Id ,d.NameAr,d.NameEn,count(s.id) as StudentCount 
        from Departments d left join Students s on d.Id =s.Id
        where d.Id=Case when @DepartmentId=0 then d.Id else  @DepartmentId end
        group by d.Id ,d.NameAr ,d.NameEn
        end
        select * from #temp
      */
    public class DepartmentStudentCountProc:GeneralLocalizableEntity
    {
        public int Id { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public int StudentCount { get; set; }
    }

    public class DepartmentStudentCountProcParamater
    {
        public int DepartmentId { get; set; } = 0;

    }
}
