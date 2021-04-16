using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Size
    {
        public Size()
        {
            this.Order_Size = new HashSet<Order_Size>();
        }
        [Key]
        public int Size_ID { get; set; }
        [Required]
        public string Size_Description { get; set; }
        [Required]
        public double Size_Price { get; set; }

        public virtual ICollection<Order_Size> Order_Size { get; set; }
    }
}