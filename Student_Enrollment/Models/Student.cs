using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Student_Enrollment.Models
{
    public class Student
    {
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public Course Course { get; set; }

        [Required]
        public int CourseId { get; set; }

        [Required]
        public bool Passing { get; set; }

        [Required]
        [Display(Name ="Hours of sleep")]
        public int HoursOfSleep { get; set; }
    }
}
