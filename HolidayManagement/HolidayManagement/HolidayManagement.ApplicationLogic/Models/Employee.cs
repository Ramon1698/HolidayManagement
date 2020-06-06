using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Models
{
    public class Employee : DataEntity
    {
        public string UserId { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }
        public int HolidayDays { get; private set; }
        public int AvailableHoldayDays { get; private set; }

        public static Employee Create(string userId,
                                      string name,
                                      string email,
                                      string phone,
                                      int holidayDays)
        {
            return new Employee
            {
                Id = Guid.NewGuid(),
                UserId = userId,
                Name = name,
                Email = email,
                PhoneNumber = phone,
                HolidayDays = holidayDays,
                AvailableHoldayDays = holidayDays
            };
        }

        public Employee Update(string name, string email, string phone, int availableDays)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phone;
            this.AvailableHoldayDays = availableDays;
            return this;
        }

        public int UpdateAvailableHolidayDays(int availableDays)
        {
            this.AvailableHoldayDays -= availableDays;
            return this.AvailableHoldayDays;
        }

        public int UpdateHolidayDays(int holidayDays)
        {
            this.HolidayDays = holidayDays;
            return this.HolidayDays;
        }
    }
}
