using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class DepartmentConfiguration : IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NameEn)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.NameAr)
              .HasColumnType("NVARCHAR")
              .HasMaxLength(50)
              .IsRequired();



            #region relationShip


            #region 1 to 1 Instructor & Department
            builder.HasOne(d => d.InstructorManager)
               .WithOne(i => i.Department)
            .HasForeignKey<Department>(x => x.InstructorManagerId)
            .IsRequired();

            builder.HasIndex(x => x.InstructorManagerId).IsUnique();
            #endregion

            #region Department -- Students
            builder.HasMany(d => d.Students)
                   .WithOne(s => s.Department)
                   .HasForeignKey(s => s.DepartmentId)
                   .IsRequired();


            #endregion

            #region m to m Department -- Subjects 
            builder
                .HasMany(d => d.Subjects)
                .WithMany(sub => sub.Departments)
                .UsingEntity<DepartmetSubject>(

                r => r.HasOne(r => r.Subjects).WithMany(r => r.DepartmetsSubjects).HasForeignKey(x => x.SubjectId),
                l => l.HasOne(x => x.Department).WithMany(x => x.DepartmentSubjects).HasForeignKey(x => x.DepartmentId),
                x => x.HasKey(x => new { x.SubjectId, x.DepartmentId })


                 );
            #endregion

            #region m to 1 Instructor & Department
            //builder.HasMany(d => d.Instructors)
            //    .WithOne(i => i.Department)
            //    .HasForeignKey(i => i.DepartmentId)
            //    .IsRequired(false);

            #endregion

            #region ....
            #endregion

            #endregion

            builder.ToTable("Departments");

        }
    }
}
