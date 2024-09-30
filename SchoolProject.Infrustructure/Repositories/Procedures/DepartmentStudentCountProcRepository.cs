using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.Interface.Procedures;
using StoredProcedureEFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories.Procedures
{
    public class DepartmentStudentCountProcRepository : IDepartmentStudentCountProcRepository
    {

        #region Vars / Props / field
        private readonly AppDbContext _appDbContext;
        #endregion

        #region Constructor(s)
        public DepartmentStudentCountProcRepository(AppDbContext appDbContext)
        {
            this._appDbContext = appDbContext;
        }

        #endregion


        #region Methods


        public async Task<IReadOnlyList<DepartmentStudentCountProc>> GetDepartmentStudentCountProcRepositoryAsync(DepartmentStudentCountProcParamater paramater)
        {
            var raws =new  List<DepartmentStudentCountProc>();
            await _appDbContext.LoadStoredProc(nameof(DepartmentStudentCountProc))
                .AddParam(nameof(DepartmentStudentCountProcParamater.DepartmentId), paramater.DepartmentId)
                .ExecAsync(async r => raws = await r.ToListAsync<DepartmentStudentCountProc>());
            return raws;
        }
        #endregion

        #region Actions

        #endregion
    }
}
