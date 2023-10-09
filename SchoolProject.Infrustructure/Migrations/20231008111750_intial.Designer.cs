﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SchoolProject.Infrustructure.Context;

#nullable disable

namespace SchoolProject.Infrustructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20231008111750_intial")]
    partial class intial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("Departments", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmetSubject", b =>
                {
                    b.Property<int>("DepId")
                        .HasColumnType("int");

                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectsId")
                        .HasColumnType("int");

                    b.HasKey("DepId", "SubId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("SubjectsId");

                    b.ToTable("DepartmetSubjects", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<int?>("DID")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("NVARCHAR");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.HasIndex("DID");

                    b.ToTable("Students", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.Property<int>("StudId")
                        .HasColumnType("int");

                    b.Property<int>("SubId")
                        .HasColumnType("int");

                    b.Property<int>("StudentId")
                        .HasColumnType("int");

                    b.Property<int>("SubjectId")
                        .HasColumnType("int");

                    b.HasKey("StudId", "SubId");

                    b.HasIndex("StudentId");

                    b.HasIndex("SubjectId");

                    b.ToTable("StudentSubjects", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.Property<DateTime>("Period")
                        .HasColumnType("Date")
                        .HasColumnName("Period");

                    b.HasKey("Id");

                    b.ToTable("Subjects", (string)null);
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.DepartmetSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("DepartmentSubjects")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subjects")
                        .WithMany("DepartmetsSubjects")
                        .HasForeignKey("SubjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Subjects");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Student", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Department", "Department")
                        .WithMany("Students")
                        .HasForeignKey("DID");

                    b.Navigation("Department");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.StudentSubject", b =>
                {
                    b.HasOne("SchoolProject.Data.Entities.Student", "Student")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SchoolProject.Data.Entities.Subject", "Subject")
                        .WithMany("StudentsSubjects")
                        .HasForeignKey("SubjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");

                    b.Navigation("Subject");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Department", b =>
                {
                    b.Navigation("DepartmentSubjects");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("SchoolProject.Data.Entities.Subject", b =>
                {
                    b.Navigation("DepartmetsSubjects");

                    b.Navigation("StudentsSubjects");
                });
#pragma warning restore 612, 618
        }
    }
}
