using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Controllers;
using Student_Enrollment.Data;
using Student_Enrollment.Models;
using System;
using System.Linq;
using Xunit;

namespace Enrollment_Test
{
    public class CourseControllerTest
    {
        [Fact]
        public async void DatabaseCanSaveAsync()
        {
            DbContextOptions<EnrollmentDbContext> options =
                new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (EnrollmentDbContext context = new EnrollmentDbContext(options))
            {
                Course course = new Course();
                course.ClassName = ClassName.Python;
                course.Instructor = "Miss Snake";
                course.StartingDate = new DateTime(2012, 12, 12);
                course.EndDate = new DateTime(2012, 12, 25);

                await context.Course.AddAsync(course);
                await context.SaveChangesAsync();

                var results = context.Course.Where(a => a.Instructor == "Miss Snake");

                Assert.Equal(1, results.Count());
            }
        }

        [Fact]
        public async void CourseControllerCanUpdateAsync()
        {
            DbContextOptions<EnrollmentDbContext> options =
                new DbContextOptionsBuilder<EnrollmentDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            using (EnrollmentDbContext context = new EnrollmentDbContext(options))
            {
                Course course = new Course();
                course.ClassName = ClassName.Python;
                course.Instructor = "Miss Snake";
                course.StartingDate = new DateTime(2012, 12, 12);
                course.EndDate = new DateTime(2012, 12, 25);

                CourseController cc = new CourseController(context);
                var x = cc.Create(course);

                var results = context.Course.Where(a => a.Instructor == "Miss Snake");

                Assert.Equal(1, results.Count());
            }
        }
    }
}
