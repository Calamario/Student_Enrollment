using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Models
{
    public class Course
    {
        public int ID { get; set; }

        [Required]
        public ClassName ClassName { get; set; }

        [Required]
        public string Instructor { get; set; }

        [Required]
        [Display(Name ="Daytime Course")]
        public bool dayTrack { get; set; }

        [Required]
        public List<Student> Cohort { get; set; }

    }

    public enum ClassName
    {
        [Display(Name = "401 - Advanced JavaScirpt")] JavaScript,
        [Display(Name = "401 - Advanced ASP.NET Core")] CSharp,
        [Display(Name = "401 - Advanced Java")] Java,
        [Display(Name = "401 - Advanced Python")] Python,
    }
}
