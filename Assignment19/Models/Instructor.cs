using Assignment19.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models
{
    public class Instructor
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public string? ShortBio { get; set; }
        public DateTime DateOfJoin { get; set; }
        public ICollection<CourseInstructor> CoursesInstructed { get; set; } = new List<CourseInstructor>();
    }
}
