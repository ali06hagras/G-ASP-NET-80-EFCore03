using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models.JunctionTables
{
    public class CourseInstructor
    {
        [Key]
        public int CourseId { get; set; }//PK
        public Course Course { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
    }
}
