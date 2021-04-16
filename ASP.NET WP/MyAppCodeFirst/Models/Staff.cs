using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Staff
    {
        public Staff()
        {
            this.Orders = new HashSet<Order>();
        }
        [Key]
        public int Staff_ID { get; set; }
        [Required]
        public string Staff_FirstName { get; set; }
        [Required]
        public string Staff_LastName { get; set; }
        [Required]
        public string Staff_Phone { get; set; }
        [Required]
        public string Staff_Email { get; set; }
        [Required]
        public string Staff_Roles { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}