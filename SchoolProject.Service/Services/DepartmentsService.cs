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
    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDepartmentsRepository _repository;

        public DepartmentsService(IDepartmentsRepository repository)
        {
            this._repository = repository;
        }
        public async Task<Department> GetDepartmentById_Include_Async(int id)
        {
            var result = await _repository.GetTableNoTracking().Where(x => x.Id.Equals(id))
                .Include(x => x.DepartmentSubjects).ThenInclude(x=>x.Subjects)
                //.Include(x => x.Students)
                .Include(x => x.Instructors).FirstOrDefaultAsync();
            return result!;   
        }
    }
}
