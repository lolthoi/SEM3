using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstAndAnnotation.Models
{
    public class StudentAddress
    {
        [Key]
        public int StudentAddessID { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public virtual Student Student { get; set; }
    }
}