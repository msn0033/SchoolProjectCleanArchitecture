using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context.Config
{
    internal class InstructorConfiguration : IEntityTypeConfiguration<Instructor>
    {
        public void Configure(EntityTypeBuilder<Instructor> builder)
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
             .HasMaxLength(50)
             .IsRequired();
            builder.Property(x => x.Postion)
             .HasColumnType("NVARCHAR")
             .HasMaxLength(50)
             .IsRequired();

            builder.Property(x => x.Salary)
             .HasPrecision(15, 2);

          

            #region RelationShip

            #region m to 1 Instructor & Instructor
            builder.HasMany(i => i.Instructors)
                .WithOne(i => i.Instructo)
                .HasForeignKey(i => i.InstructoId)
                .IsRequired(false);
            #endregion

            #region ....
            #endregion

            #endregion



            builder.ToTable("Instructors");

        }
    }
}
