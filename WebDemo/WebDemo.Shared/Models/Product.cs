using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebDemo.Shared.Models
{
    //[Table(name:"Product")]
    public class Product
    {
        [Display(Name = "Product Id")]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"[A-Z]\-[0-9]")]
        public string ProductName { get; set; }
        public int SupplierId { get; set; }

        [DataType(DataType.Currency)]
        public decimal UnitPrice { get; set; }
        public string Package { get; set; }
        public bool IsDiscontinued { get; set; }

    }
}
