using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IDepartmentsService
    {
        Task<Department> GetDepartmentById_Include_Async(int id);
        Task<Department> GetDepartmentIdAsync(int id);
        Task<bool> IsDepartmentIdIExistAsync(int departmentId);
        Task <List<DepartmentStudentCountView>> GetDepartmentStudentCountViewAsync();
        Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcAsync(DepartmentStudentCountProcParamater paramater);


    }
}
