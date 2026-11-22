using Assignment19.Models.JunctionTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        public DateTime DateOfBirth { get; set; }
        public ICollection<Enrollment> EnrolledCourses { get; set; }
    }
}
