using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstProject.Models
{
    public class Course
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Credit { get; set; }

        public virtual ICollection<Student_Course> Student_Courses { get; set; }
    }
}