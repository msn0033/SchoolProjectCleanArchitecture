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
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.NameEn)
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(x => x.NameAr)
            .HasColumnType("NVARCHAR")
            .HasMaxLength(100)
            .IsRequired();

            builder.Property(x => x.Period)
                .HasColumnType("Date")
                .HasColumnName("Period")
                .IsRequired();



            builder.ToTable("Subjects");

        }
    }
}
