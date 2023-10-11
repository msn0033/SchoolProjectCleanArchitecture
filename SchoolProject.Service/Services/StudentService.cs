using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
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

        public async Task<Student> GetStudentById(int id)
        {
            var student=_repositoryStudent.GetTableNoTracking()
                                          .Include(x=>x.Department)
                                          .Where(x=>x.Id == id)
                                          .FirstOrDefault();
            
            return student!;
  
        }

        public async Task<string> AddStudentAsync(Student student)
        {
            var check =_repositoryStudent.GetTableNoTracking().FirstOrDefault(x => x.Name.Equals(student.Name));
            if (check !=null)
                return "Exist";
            else if (await _repositoryStudent.AddAsync(student) == null)
                return "problem in add students to data base";
            return "Success";


           

        }
    }
}
