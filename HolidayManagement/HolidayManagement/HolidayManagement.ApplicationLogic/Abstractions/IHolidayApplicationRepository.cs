using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Abstractions
{
    public interface IHolidayApplicationRepository : IBaseRepository<HolidayApplication>
    {
        IEnumerable<HolidayApplication> GetAllForEmployee(Guid id);
    }
}
