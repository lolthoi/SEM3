using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Payment
    {
        public Payment()
        {
            this.Customer_Payment = new HashSet<Customer_Payment>();
        }
        [Key]
        public int Payment_ID { get; set; }
        [Required]
        public string Payment_Method { get; set; }
        [Required]
        public string Payment_Status { get; set; }

        public virtual ICollection<Customer_Payment> Customer_Payment { get; set; }
    }
}