using Assignment19.Enums;
using Assignment19.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models
{
    public class Course
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public CourseLevelEnum Level { get; set; }
        public bool IsPublished { get; set; }
        public DateTime? PublishingDate { get; set; }// make it set automatichally with GETDATE() if it is published
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public ICollection<Enrollment> EnrolledStudents { get; set; }
    }
}
