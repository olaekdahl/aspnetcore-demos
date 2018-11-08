﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdventureWorks.Shared.Models
{
    public class Employee
    {
        [Key]
        [Column("BusinessEntityID")]
        public int EmployeeId { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Suffix { get; set; }
        public string JobTitle { get; set; }
        public string Department { get; set; }
        public string GroupName { get; set; }
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
    }
}
