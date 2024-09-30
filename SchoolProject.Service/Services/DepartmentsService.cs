using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrustructure.Interface;
using SchoolProject.Infrustructure.Interface.Procedures;
using SchoolProject.Infrustructure.Interface.Views;
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



        #region Vars / Props / field
        private readonly IDepartmentsRepository _departmentsRepository;
        private readonly IViewRepository<DepartmentStudentCountView> _viewDepartmentRepository;
        private readonly IDepartmentStudentCountProcRepository _departmentStudentCountProcRepository;

        #endregion

        #region Constructor(s)
        public DepartmentsService(IDepartmentsRepository departmentsRepository, IViewRepository<DepartmentStudentCountView> viewRepository
          , IDepartmentStudentCountProcRepository departmentStudentCountProcRepository)
        {
            this._departmentsRepository = departmentsRepository;
            this._viewDepartmentRepository = viewRepository;
            this._departmentStudentCountProcRepository = departmentStudentCountProcRepository;
        }

        #endregion


        #region Methods
        public async Task<Department> GetDepartmentById_Include_Async(int id)
        {
            var result = await _departmentsRepository.GetTableNoTracking().Where(x => x.Id.Equals(id))
                .Include(x => x.DepartmentSubjects).ThenInclude(x => x.Subjects)
                //.Include(x => x.Students)
                .Include(x => x.Instructors).FirstOrDefaultAsync();
            return result!;
        }

        public async Task<Department> GetDepartmentIdAsync(int id)
        {
            var department = await _departmentsRepository.GetByIdAsync(id);

            return department;
        }

        public async Task<bool> IsDepartmentIdIExistAsync(int departmentId)
        {
            return await _departmentsRepository.GetTableNoTracking().AnyAsync(x => x.Id == departmentId);
        }

        // view GetDepartmentStudentCountView
        public Task<List<DepartmentStudentCountView>> GetDepartmentStudentCountViewAsync()
        {
            return _viewDepartmentRepository.GetTableNoTracking().ToListAsync();
        }

        //Procedure DepartmentStudentCountProc
        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcAsync(DepartmentStudentCountProcParamater paramater)
        {
            return await _departmentStudentCountProcRepository.GetDepartmentStudentCountProcRepositoryAsync(paramater);
        }
        #endregion

        #region Actions

        #endregion
    }

  
}
