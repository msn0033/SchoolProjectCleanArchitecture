using SchoolProject.Data.Data;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Service.Services
{
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _repositoryStudent;

        public StudentService(IStudentRepository repository)
        {
            this._repositoryStudent = repository;
        }
        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _repositoryStudent.GetStudentsAsync();
        }
    }
}
