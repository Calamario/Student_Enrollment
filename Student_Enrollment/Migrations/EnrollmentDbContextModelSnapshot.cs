﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Student_Enrollment.Data;

namespace Student_Enrollment.Migrations
{
    [DbContext(typeof(EnrollmentDbContext))]
    partial class EnrollmentDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.0-rtm-30799")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Student_Enrollment.Models.Course", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassName");

                    b.Property<DateTime>("EndDate");

                    b.Property<string>("Instructor")
                        .IsRequired();

                    b.Property<DateTime>("StartingDate");

                    b.HasKey("ID");

                    b.ToTable("Course");
                });

            modelBuilder.Entity("Student_Enrollment.Models.Student", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CourseId");

                    b.Property<int>("HoursOfSleep");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<bool>("Passing");

                    b.HasKey("ID");

                    b.HasIndex("CourseId");

                    b.ToTable("Student");
                });

            modelBuilder.Entity("Student_Enrollment.Models.Student", b =>
                {
                    b.HasOne("Student_Enrollment.Models.Course", "Course")
                        .WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
