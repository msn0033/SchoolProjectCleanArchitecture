using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities.Views;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Infrustructure.Interface.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories.Views
{
    public class ViewDepartmentRepository : GenericRepositoryAsync<DepartmentStudentCountView>, IViewRepository<DepartmentStudentCountView>
    {
        public DbSet<DepartmentStudentCountView> _ViewDepartments;
        public ViewDepartmentRepository(AppDbContext dbContext) : base(dbContext)
        {
            _ViewDepartments=dbContext.Set<DepartmentStudentCountView>();
        }
    }
}
