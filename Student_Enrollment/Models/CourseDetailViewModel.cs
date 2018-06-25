using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Models
{
    public class CourseDetailViewModel
    {
        public IEnumerable<Student> Students { get; set; }
        public Course Course { get; set; }

        public static async Task<CourseDetailViewModel> FromIDAsync(int id, EnrollmentDbContext context)
        {
            CourseDetailViewModel cdvm = new CourseDetailViewModel();

            cdvm.Course = await context.Course.Where(c => c.ID == id).SingleAsync();

            cdvm.Students = await context.Student.Where(s => s.Course == cdvm.Course)
                                                    .Select(s => s)
                                                    .ToListAsync();

            return cdvm;
        }
    }
}
