namespace DBFirstAndLINQ2SQL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("production.products")]
    public partial class product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public product()
        {
            order_items = new HashSet<order_items>();
        }

        [Key]
        public int product_id { get; set; }

        [Required]
        [StringLength(255)]
        public string product_name { get; set; }

        public int brand_id { get; set; }

        public int category_id { get; set; }

        public short model_year { get; set; }

        public decimal list_price { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<order_items> order_items { get; set; }
    }
}
