using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    [Table("StudentInfo", Schema = "Admin")]
    public class Student
    {
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        [Column(Order = 1)]
        public string FirstName { get; set; }
        [Column(Order = 2)]
        public string LastName { get; set; }
        [Column("Date of birth", Order = 3)]
        public DateTime? DoB { get; set; }
        [Column(Order = 4)]
        public string Phone { get; set; }
        [NotMapped]
        public int Age { get; set; }
        public virtual Grade Grade { get; set; }
        public virtual Address Address { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
        public virtual ICollection<StudentClass> StudentClasses { get; set; }
    }
}