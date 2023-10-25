using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;

namespace SchoolProject.Infrustructure.Context
{
    public class AppDbContext : DbContext
    {

        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        
         
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }





        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
