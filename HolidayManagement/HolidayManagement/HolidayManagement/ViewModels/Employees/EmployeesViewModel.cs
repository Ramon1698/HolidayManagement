using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.ViewModels.Employees
{
    public class EmployeesViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
    }
}
