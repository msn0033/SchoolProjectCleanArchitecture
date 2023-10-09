using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _dbContext;

        public StudentRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
      

        public async Task<IEnumerable<Student>> GetStudentsAsync()
        {
            return await _dbContext.Students.Include(d=>d.Department).ToListAsync();
        }
        public async Task<Student> GetById(int id)
        {
            return await _dbContext.Students.FindAsync(id);
        }

        public void Insert(Student student)
        {
            throw new NotImplementedException();
        }

        public void Update(Student student)
        {
            throw new NotImplementedException();
        }
        public void Delete(Student student)
        {
            throw new NotImplementedException();
        }
    }
}
