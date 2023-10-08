using SchoolProject.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
    }
}
