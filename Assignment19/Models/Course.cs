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
        public CourseLevel Level { get; set; }
        public bool IsPublished { get; set; }
        public CourseInstructor? PublisherInstructor { get; set; }
        public CourseCategory? CategoryedCourse { get; set; }
    }
}
