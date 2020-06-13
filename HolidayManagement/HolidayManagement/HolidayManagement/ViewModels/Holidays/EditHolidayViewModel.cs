using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HolidayManagement.ViewModels.Holidays
{
    public class EditHolidayViewModel
    {
        public Guid Id { get; set; }

        [Display(Name = "Holiday Name")]
        [Required]
        public string Type { get; set; }

        [Display(Name = "Number Of Days")]
        [Required]
        public int Days { get; set; }

        [Required]
        public string Description { get; set; }

    }
}
