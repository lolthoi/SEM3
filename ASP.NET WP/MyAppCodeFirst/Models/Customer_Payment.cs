using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Customer_Payment
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Customer_Id { get; set; }
        [Required]
        public int Payment_Id { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Payment Payment { get; set; }
    }
}