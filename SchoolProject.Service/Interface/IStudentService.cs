using SchoolProject.Data.Entities;
using SchoolProject.Helper.Enums;

namespace SchoolProject.Service.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsListwithIncludeAsync();
        Task<Student> GetStudentByIdWithIncludeAsync(int id);
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddStudentAsync(Student student);
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistExculdeSelf(string key, int id);
        Task<string> EditStudentAsync(Student student);
        Task<string> DeleteAsync(Student student);
        IQueryable<Student> GetStudents_Include_List_ASQuerable_Search_Or_OrderBy(string? search, StudentOrderByEnum order);
        IQueryable<Student> GetStudents_By_Dipartment_Id(int id);
    }
}
