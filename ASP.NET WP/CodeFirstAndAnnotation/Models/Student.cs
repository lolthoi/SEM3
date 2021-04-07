using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeFirstAndAnnotation.Models
{
    public class Student
    {
        public int StudentID { get; set; }
        public string StudentName { get; set; }
        public string Phone { get; set; }
        public DateTime? DoB { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual StudentAddress Address { get; set; }
        public virtual ICollection<Course> Courses { get; set; }

    }
}