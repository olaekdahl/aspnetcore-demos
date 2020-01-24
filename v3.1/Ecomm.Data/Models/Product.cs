using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Ecomm.Data.Models
{
    [Table("Inventory")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Column("ProductName")]
        [Required]
        [StringLength(2)]
        public string Name { get; set; }
        public decimal UnitPrice { get; set; }
        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

    }
}
