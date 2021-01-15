using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EComm.Shared.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [NotMapped]
        public string City { get; set; }
        [NotMapped]
        public string Country { get; set; }
        [NotMapped]
        public string Phone { get; set; }
    }
}
