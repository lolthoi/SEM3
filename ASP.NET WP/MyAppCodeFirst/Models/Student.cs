using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Student
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime? DoB { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}