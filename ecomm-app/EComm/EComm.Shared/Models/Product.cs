using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EComm.Shared.Models
{ 
    // [Table("Iventory")]
    public class Product
    {
        [Column("Id")]
        [DisplayName("Id")]
        public int ProductId { get; set; }
        [Column("ProductName")]
        [Required(ErrorMessage ="The product name can not be empty.")]
        public string Name { get; set; }
        [Column("UnitPrice")]
        [DisplayName("Unit Price")]
        [DataType(DataType.Currency)]
        [Required]
        [Range(1.00, 5000.00, ErrorMessage = "The product price has to be between $1.00 and $5,000.00.")]
        public decimal Price { get; set; }
        public int SupplierId { get; set; }
        public bool IsDiscontinued { get; set; }
    }
}
