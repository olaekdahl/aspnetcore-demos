using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace AdventureWorks.Shared.Models
{
    public class Department
    {
        [Key]
        public short DepartmentID { get; set; }

        [Column("Name")]
        public string DepartmentName { get; set; }
    }
}
