using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Customer_Payment = new HashSet<Customer_Payment>();
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int Customer_ID { get; set; }
        [Required]
        public string Customer_FirstName { get; set; }
        [Required]
        public string Customer_LastName { get; set; }
        [Required]
        public string Customer_Phone { get; set; }
        [Required]
        public string Customer_Email { get; set; }
        [Required]
        public string Customer_Address { get; set; }

        public virtual ICollection<Customer_Payment> Customer_Payment { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}