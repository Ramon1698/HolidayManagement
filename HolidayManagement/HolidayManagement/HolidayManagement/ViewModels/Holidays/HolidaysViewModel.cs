using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.ViewModels.Holidays
{
    public class HolidaysViewModel
    {
        public IEnumerable<Holiday> Holidays { get; set; }
    }
}
