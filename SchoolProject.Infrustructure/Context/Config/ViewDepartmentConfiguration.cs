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
    public class ViewDepartmentConfiguration : IEntityTypeConfiguration<ViewDepartment>
    {
        public void Configure(EntityTypeBuilder<ViewDepartment> builder)
        {
            builder.ToView("ViewDepartment", schema: "dbo")
                   .HasNoKey();
        }
    }
}
