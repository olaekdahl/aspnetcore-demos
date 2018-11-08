﻿using AdventureWorks.Shared.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventureWorks.Shared.ViewModels
{
    public class EmployeeViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<Department> Departments { get; set; }
        public IEnumerable<SelectListItem> DepartmentList
        {
            get
            {
                if(Departments != null)
                {
                    return from d in Departments
                           select new SelectListItem
                           {
                               Text = d.DepartmentName,
                               Value = d.DepartmentID.ToString(),
                               Selected = (Employee == null ? d.DepartmentName == "" : d.DepartmentName == Employee.Department)
                           };
                }
                return null;
            }
        }
    }
}
