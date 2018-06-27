using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Controllers;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using System;
using System.Linq;
using Xunit;


namespace Enrollment_Test
{
    public class StudentControllerTest
    {
        [Fact]
        public void StudentControllerCanSave()
        {
            DbContextOptions<EnrollmentDbContext> options =
                new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (EnrollmentDbContext context = new EnrollmentDbContext(options))
            {
                Course course = new Course();
                course.ID = 3;
                course.ClassName = ClassName.Python;
                course.Instructor = "Miss Snake";
                course.StartingDate = new DateTime(2012, 12, 12);
                course.EndDate = new DateTime(2012, 12, 25);

                Student student = new Student();
                student.Name = "Mario";
                student.CourseId = 3;
                student.Passing = true;
                student.HoursOfSleep = 5;

                CourseController cc = new CourseController(context);
                var y = cc.Create(course);

                StudentController sc = new StudentController(context);
                var x = sc.Create(student);

                var results = context.Student.Where(a => a.Name == "Mario");

                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public void StudentControllerCanDelete()
        {
            DbContextOptions<EnrollmentDbContext> options =
                new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (EnrollmentDbContext context = new EnrollmentDbContext(options))
            {
                Course course = new Course();
                course.ID = 3;
                course.ClassName = ClassName.Python;
                course.Instructor = "Miss Snake";
                course.StartingDate = new DateTime(2012, 12, 12);
                course.EndDate = new DateTime(2012, 12, 25);

                Student student = new Student();
                student.Name = "Mario";
                student.CourseId = 3;
                student.Passing = true;
                student.HoursOfSleep = 5;

                CourseController cc = new CourseController(context);
                var y = cc.Create(course);

                StudentController sc = new StudentController(context);
                var x = sc.Create(student);
                var z = sc.Delete(1);

                var results = context.Student.Where(a => a.Name == "Mario");

                Assert.Equal(0, results.Count());
            }
        }

        [Fact]
        public void StudentControllerCanUpdate()
        {
            DbContextOptions<EnrollmentDbContext> options =
                new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (EnrollmentDbContext context = new EnrollmentDbContext(options))
            {
                Course course = new Course();
                course.ID = 3;
                course.ClassName = ClassName.Python;
                course.Instructor = "Miss Snake";
                course.StartingDate = new DateTime(2012, 12, 12);
                course.EndDate = new DateTime(2012, 12, 25);

                Student student = new Student();
                student.Name = "Mario";
                student.CourseId = 3;
                student.Passing = true;
                student.HoursOfSleep = 5;

                Student newStudent = new Student();
                student.Name = "Mario";
                student.CourseId = 3;
                student.Passing = false;
                student.HoursOfSleep = 5;

                CourseController cc = new CourseController(context);
                var y = cc.Create(course);

                StudentController sc = new StudentController(context);
                var x = sc.Create(student);

                var z = sc.Update(newStudent);

                var results = context.Student.Where(a => a.Name == "Mario");

                Assert.Equal(1, results.Count());
                Assert.False(context.Student.Where(a => a.Name == "Mario").SingleOrDefault().Passing);
            }
        }
    }
}
