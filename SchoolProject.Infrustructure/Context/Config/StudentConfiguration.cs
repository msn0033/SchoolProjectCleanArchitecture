using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
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

            builder.Property(x => x.Address)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(100)
               .IsRequired();

            builder.Property(x => x.Phone)
               .HasColumnType("NVARCHAR")
               .HasMaxLength(20)
               .IsRequired();



            #region Students -- Subjects
            builder.HasMany(stu => stu.Subjects)
                .WithMany(sub => sub.Students)
                .UsingEntity<StudentSubject>(
                r => r.HasOne(x => x.Subject).WithMany(x => x.StudentsSubjects).HasForeignKey(x => x.SubjectId),
                l => l.HasOne(x => x.Student).WithMany(x => x.StudentsSubjects).HasForeignKey(x => x.StudentId),
                k => k.HasKey(x => new { x.SubjectId, x.StudentId })
                );


            #endregion


            builder.ToTable("Students");



        }
    }
}
