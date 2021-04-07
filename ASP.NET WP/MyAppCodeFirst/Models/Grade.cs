using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Grade
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Section { get; set; }
        public ICollection<Student> Students { get; set; }
    }
}