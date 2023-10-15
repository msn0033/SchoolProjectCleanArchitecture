﻿using SchoolProject.Data.Entities;

namespace SchoolProject.Service.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>> GetStudentsAsync();
        Task<Student> GetStudentByIdAsync(int id);
        Task<string> AddStudentAsync(Student student);
        Task<bool> IsNameExist(string name);
        Task<bool> IsNameExistExculdeSelf(string key, int id);
        Task<string> EditStudentAsync(Student student);
    }
}
