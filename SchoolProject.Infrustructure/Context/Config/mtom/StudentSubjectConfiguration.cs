using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context.Config.mtom
{
    internal class StudentSubjectConfiguration : IEntityTypeConfiguration<StudentSubject>
    {
        public void Configure(EntityTypeBuilder<StudentSubject> builder)
        {
            //builder.HasKey(x => new { x.SubjectId, x.StudentId });

            builder.ToTable("StudentSubjects");

        }
    }
}
