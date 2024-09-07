using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Repositories;
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
        private readonly IDepartmentsRepository _departmentsRepository;

        public DepartmentsService(IDepartmentsRepository departmentsRepository)
        {
            this._departmentsRepository = departmentsRepository;
        }
        public async Task<Department> GetDepartmentById_Include_Async(int id)
        {
            var result = await _departmentsRepository.GetTableNoTracking().Where(x => x.Id.Equals(id))
                .Include(x => x.DepartmentSubjects).ThenInclude(x=>x.Subjects)
                //.Include(x => x.Students)
                .Include(x => x.Instructors).FirstOrDefaultAsync();
            return result!;   
        }

        public async Task<Department> GetDepartmentIdAsync(int id)
        {
            var department =await _departmentsRepository.GetByIdAsync(id);

            return department;
        }

        public async Task<bool> IsDepartmentIdIExistAsync(int departmentId)
        {
           return await _departmentsRepository.GetTableNoTracking().AnyAsync(x=>x.Id== departmentId);
        }
    }
}
