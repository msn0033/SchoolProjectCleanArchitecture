using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Name)
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
                .UsingEntity<StudentSubject>();


            #endregion


            builder.ToTable("Students");



        }
    }
}
