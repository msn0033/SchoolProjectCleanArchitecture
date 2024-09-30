using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Context.Config
{
    public class DepartmentStudentCountProcConfiguration : IEntityTypeConfiguration<DepartmentStudentCountProc>
    {
        public void Configure(EntityTypeBuilder<DepartmentStudentCountProc> builder)
        {
            builder.HasNoKey();
        }
    }
}
