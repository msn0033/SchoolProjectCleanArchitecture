using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.GenericRepository;

namespace SchoolProject.Infrustructure.Interface
{
    public interface IStudentRepository : IGenericRepositoryAsync<Student>
    {
        Task<IEnumerable<Student>> GetStudentsListWithIncludeAsync();

    }
}
