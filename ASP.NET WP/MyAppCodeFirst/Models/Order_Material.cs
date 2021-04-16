using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Order_Material
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public int Order_Id { get; set; }
        [Required]
        public int Material_Id { get; set; }
        [Required]
        public int quantity { get; set; }

        public virtual Material Material { get; set; }
        public virtual Order Order { get; set; }
    }
}