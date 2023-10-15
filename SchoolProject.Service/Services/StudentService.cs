using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Service.Interface;

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

        public async Task<Student> GetStudentByIdAsync(int id)
        {
            var student = await _repositoryStudent.GetTableNoTracking()
                                          .Include(x => x.Department)
                                          .Where(x => x.Id == id)
                                          .FirstOrDefaultAsync();

            return student!;

        }

        public async Task<string> AddStudentAsync(Student student)
        {
            await _repositoryStudent.AddAsync(student);
            return "Success";
        }

        public async Task<bool> IsNameExist(string name)
        {
            var student = await _repositoryStudent.GetTableNoTracking().Where(x => x.Name == name).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;

        }

        public async Task<bool> IsNameExistExculdeSelf(string key, int id)
        {
            var student = await _repositoryStudent.GetTableNoTracking().Where(x => x.Name == key & !(x.Id == id)).FirstOrDefaultAsync();
            if (student == null) return false;
            return true;
        }

        public async Task<string> EditStudentAsync(Student student)
        {
            await _repositoryStudent.UpdateAsync(student);
            return "Edit is Success";
        }
    }
}
