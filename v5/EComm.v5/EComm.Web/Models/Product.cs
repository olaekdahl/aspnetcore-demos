using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Web.Models
{
    public class Product
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "You must provide a product name.")]
        public string ProductName { get; set; }
        [DisplayName("Price")]
        [Required]
        [Range(0, 999.99)]
        public decimal UnitPrice { get; set; }
        public bool IsDiscontinued { get; set; }
        public int SupplierId { get; set; }
    }
}
