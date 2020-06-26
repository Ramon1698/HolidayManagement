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
        public int ConsumedHolidayDays { get; private set; }

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
                ConsumedHolidayDays = 0
            };
        }

        public Employee Update(string name, string email, string phone, int availableDays)
        {
            this.Name = name;
            this.Email = email;
            this.PhoneNumber = phone;
            this.HolidayDays = availableDays;
            return this;
        }

        public int UpdateConsumedHolidayDays(int holidayDays)
        {
            this.ConsumedHolidayDays = holidayDays;
            return this.ConsumedHolidayDays;
        }
    }
}
