using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class SubjectConfiguration : IEntityTypeConfiguration<Subject>
    {
        public void Configure(EntityTypeBuilder<Subject> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.NameEn)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.NameAr)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

            //builder.Property(x => x.Period)
            //    .HasColumnType("Date")
            //    .HasColumnName("Period")
            //    .IsRequired();

            #region RelationShip
            #region m to m Subject & Instructor

            builder.HasMany(s => s.Instructors)
                .WithMany(i => i.Subjects)
                .UsingEntity<InstructorSubject>(
                 l => l.HasOne(x => x.Instructor).WithMany(x => x.InstructorSubjects).HasForeignKey(x => x.InstructorId),
                 l => l.HasOne(x => x.Subject).WithMany(x => x.InstructorSubjects).HasForeignKey(x => x.SubjectId),
                 k => k.HasKey(x => new { x.SubjectId, x.InstructorId })
                );
            #endregion
            #region ....
            #endregion
            #endregion

            builder.ToTable("Subjects");

        }
    }
}
