using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MyImage.Models
{
    [Table("Payment", Schema = "sales")]
    public class Payment
    {
        [Key]
        public int ID { get; set; }
        public string MethodName { get; set; }
        public int Status { get; set; }
    }
}