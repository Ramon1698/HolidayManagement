using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.ViewModels.HolidayApplication
{
    public class HolidayApplicationViewModel
    {
        public Employee Employee { get; set; }
        public IEnumerable<HolidayManagement.ApplicationLogic.Models.HolidayApplication> HolidayApplications { get; set; }
    }
}
