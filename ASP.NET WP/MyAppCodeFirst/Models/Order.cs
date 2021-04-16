using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Order
    {
        public Order()
        {
            this.Order_Material = new HashSet<Order_Material>();
            this.Order_Size = new HashSet<Order_Size>();
        }
        [Key]
        public int Order_ID { get; set; }
        [Required]
        public string Order_Status { get; set; }
        [Required]
        public System.DateTime Order_Date { get; set; }
        [Required]
        public int Staff_Id { get; set; }
        [Required]
        public int Customer_Id { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual ICollection<Order_Material> Order_Material { get; set; }
        public virtual ICollection<Order_Size> Order_Size { get; set; }
        public virtual Staff Staff { get; set; }
    }
}