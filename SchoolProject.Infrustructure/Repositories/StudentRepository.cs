using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Infrustructure.Interface;

namespace SchoolProject.Infrustructure.Repositories
{
    public class StudentRepository : GenericRepositoryAsync<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _students;

        public StudentRepository(AppDbContext dbContext) : base(dbContext)
        {
            this._students = dbContext.Set<Student>();
        }


        public async Task<IEnumerable<Student>> GetStudentsListWithIncludeAsync()
        {
            return await _students.Include(d => d.Department).ToListAsync();
        }

    }
}
