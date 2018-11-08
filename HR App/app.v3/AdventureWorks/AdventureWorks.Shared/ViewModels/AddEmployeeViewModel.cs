using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AdventureWorks.Shared.ViewModels
{
    public class AddEmployeeViewModel : EmployeeViewModel
    {
        public string NationalIDNumber { get; set; }
        public string LoginID { get; set; }

        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public string MaritalStatus { get; set; }
        public string Gender { get; set; }

        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public bool SalariedFlag { get; set; }
        public short VacationHours { get; set; }
        public short SickLeaveHours { get; set; }
        public short DepartmentId { get; set; }
    }
}
