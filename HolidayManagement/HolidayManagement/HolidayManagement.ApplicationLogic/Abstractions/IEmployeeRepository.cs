using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Abstractions
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        Employee GetByUserId(string userId);
    }
}
