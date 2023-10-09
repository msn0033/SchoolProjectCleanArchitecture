using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();


            #region relationShip

            #region Department -- Students
            builder.HasMany(d => d.Students)
                   .WithOne(s => s.Department)
                   .HasForeignKey(s => s.DID)
                   .IsRequired(false);
            #endregion

            #region Department -- Subjects
            builder.HasMany(d => d.Subjects)
                .WithMany(sub => sub.Departments)
                .UsingEntity<DepartmetSubject>(x => x.HasKey(x => new { x.DepId, x.SubId }));
            #endregion

            #region ....
            #endregion

            #endregion

            builder.ToTable("Departments");

        }
    }
}
