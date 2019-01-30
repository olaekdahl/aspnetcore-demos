using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp.Models
{
    public class Product
    {
        [BindNever]
        public int Id { get; set; }
        public int CategoryId { get; set; }

        [Display(Name = "Product Name")]
        [Required(ErrorMessage = "You have to provide a name...")]
        public string Name { get; set; }
        public string Color { get; set; }
        public decimal? Price { get; set; }
    }
}
