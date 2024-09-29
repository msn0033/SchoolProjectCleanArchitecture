using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Context.Config
{
    public class DepartmentStudentCountViewConfiguration : IEntityTypeConfiguration<DepartmentStudentCountView>
    {
        public void Configure(EntityTypeBuilder<DepartmentStudentCountView> builder)
        {
            builder.ToView("ViewDepartment", schema: "dbo")
                   .HasNoKey();
        }
    }
}
