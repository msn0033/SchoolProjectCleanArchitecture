using SchoolProject.Infrustructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Repositories
{
    public  class InstructorsRepository
    {
        private readonly AppDbContext _dbContext;

        public InstructorsRepository(AppDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
    }
}
