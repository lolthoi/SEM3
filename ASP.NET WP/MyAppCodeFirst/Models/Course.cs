using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Course
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }

    }
}