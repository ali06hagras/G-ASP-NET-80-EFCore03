using Assignment19.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models.JunctionTables
{
    public class Enrollment
    {
        public int StudentId { get; set; } //PK (Composite)
        public Student Student { get; set; }
        public int CourseId { get; set; } //PK (Composite)
        public Course Course { get; set; }
        public DateTime EnrollmentDate { get; set; } // GetDATE()
        public int ProgressPercentage { get; set; }
        public EnrollmentStatusEnum Status { get; set; }
        public int? FinalGrade { get; set; } // only when status is completed
    }
}
