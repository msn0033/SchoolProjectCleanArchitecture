﻿
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolProject.Data.Entities;
using SchoolProject.Data.Entities.Identity;
using SchoolProject.Data.Entities.Procedures;
using SchoolProject.Data.Entities.Views;

namespace SchoolProject.Infrustructure.Context
{
    public class AppDbContext : IdentityDbContext<User,Role,int,IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        //public DbSet<User> Users { get; set; }
        //public DbSet<Role> Roles { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Instructor> Instructors { get; set; }
        public DbSet<Student> Students { get; set; }
        
         
        public DbSet<DepartmetSubject> DepartmetSubjects { get; set; }
        public DbSet<InstructorSubject> InstructorSubjects { get; set; }
        public DbSet<StudentSubject> StudentSubjects { get; set; }

        //Identity
        public DbSet<UserRefreshToken> UserRefreshTokens { get; set; }

        public DbSet<UserPermission> UserPermissions { get; set; }

        //view
        public DbSet<DepartmentStudentCountView> DepartmentStudentCountView { get; set; }

        //procedure
        public DbSet<DepartmentStudentCountProc> DepartmentStudentCountProc { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


            //// Function parmater int
            //modelBuilder.HasDbFunction(typeof(AppDbContext).GetMethod(nameof(Get_Salary_summation_of_Instructor),
            //    new[] { typeof(int) })!)
            //    .HasName(nameof(Get_Salary_summation_of_Instructor));


            //  modelBuilder.HasDbFunction(() => Get_Salary_summation_of_Instructor()).HasName("Get_Salary_summation_of_Instructor").HasSchema("dbo");

            //  modelBuilder.HasDbFunction(
            //typeof(AppDbContext).GetMethod(nameof(Get_Salary_summation_of_Instructor))!)
            //      .HasName("Get_Salary_summation_of_Instructor");


            //modelBuilder
            //.HasDbFunction(
            //    typeof(AppDbContext).GetMethod(nameof(Get_Salary_summation_of_Instructor),
            //        new[] { typeof(int)})!)
            //.HasName("Get_Salary_summation_of_Instructorr");
        }

       
       [DbFunction("Get_Salary_summation_of_Instructor", Schema ="dbo")]
       public static decimal Get_Salary_summation_of_Instructor()
        {
            throw new NotImplementedException();
        }


    }
}
