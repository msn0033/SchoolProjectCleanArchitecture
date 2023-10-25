using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Infrustructure.Context;
using SchoolProject.Infrustructure.GenericRepository;
using SchoolProject.Infrustructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public class DepartmentsRepository : GenericRepositoryAsync<Department>, IDepartmentsRepository
    {
        private readonly DbSet<Department> _department;
        public DepartmentsRepository(AppDbContext dbContext) : base(dbContext)
        {
            _department = dbContext.Departments;
        }
    }
}
