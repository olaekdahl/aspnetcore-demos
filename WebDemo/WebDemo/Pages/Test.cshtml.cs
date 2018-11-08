using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebDemo.Pages
{
    public class TestModel : PageModel
    {
        public string Name { get; set; }
        public void OnGet()
        {
            Name = "Ola";
        }
    }
}