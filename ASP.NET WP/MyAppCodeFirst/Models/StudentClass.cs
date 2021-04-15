using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class StudentClass
    {
        public StudentClass()
        {
            this.Students = new HashSet<Student>();
        }
        [Key]
        public int ID { get; set; }
        public string ClassName { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}