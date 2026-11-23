using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment19.Models.JunctionTables
{
    public class CourseCategory
    {
        [Key]
        public int CourseId { get; set; }//PK
        public Course Course { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
