using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebDemo.Shared.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        [BindNever]
        //[Scaffold(false)]
        public int Id { get; set; }

        [Required(ErrorMessage = "You must provide a customer first name.")]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        [CheckCountry("US")]
        public string Country { get; set; }
        [Required]
        [Phone]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [EmailAddress]
        [Compare("Email")]
        public string Email2 { get; set; }

        public ICollection<Order> Order { get; set; }
    }

    public class CheckCountryAttribute : ValidationAttribute
    {
        private string _country;

        public CheckCountryAttribute(string country)
        {
            _country = country;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;

            if (!customer.Country.Equals(_country))
            {
                return new ValidationResult($"The Country has to be {_country}");
            }

            return ValidationResult.Success;
        }
    }
}
