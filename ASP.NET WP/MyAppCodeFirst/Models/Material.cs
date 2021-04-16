using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyAppCodeFirst.Models
{
    public class Material
    {
        public Material()
        {
            this.Order_Material = new HashSet<Order_Material>();
        }
        [Key]
        public int Material_ID { get; set; }
        [Required]
        public string Material_Description { get; set; }
        [Required]
        public double Material_Price { get; set; }

        public virtual ICollection<Order_Material> Order_Material { get; set; }
    }
}