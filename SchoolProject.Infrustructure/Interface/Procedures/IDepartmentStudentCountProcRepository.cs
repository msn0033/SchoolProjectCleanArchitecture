using SchoolProject.Data.Entities.Procedures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Interface.Procedures
{
    public interface IDepartmentStudentCountProcRepository
    {
        Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcRepositoryAsync(DepartmentStudentCountProcParamater paramater);
    }
}
