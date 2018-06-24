using Microsoft.EntityFrameworkCore;
using Student_Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Data
{
    public class EnrollmentDbContext : DbContext
    {
        public DbSet<Course> Course { get; set; }
        public DbSet<Student> Student { get; set; }

        public EnrollmentDbContext(DbContextOptions<EnrollmentDbContext> options) : base(options)
        { 
            
        }
    }
}
