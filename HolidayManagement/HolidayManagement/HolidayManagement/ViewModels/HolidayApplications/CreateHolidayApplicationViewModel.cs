using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.ViewModels.HolidayApplication
{
    public class CreateHolidayApplicationViewModel
    {
        [Required]
        public Guid HolidayId { get; set; }
        public IEnumerable<Holiday> Holidays { get; set; }

        [Required]
        [Display(Name = "Start Day Of Holiday")]
        public DateTime StartDay { get; set; }

        [Required]
        [Display(Name = "End Day Of Holiday")]
        public DateTime EndDay { get; set; }

        [Required]
        public string Reasons { get; set; }
    }
}
