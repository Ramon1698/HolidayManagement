using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Models
{
    public enum StatusApplication { Active, Accepted, Declined}
    public class HolidayApplication : DataEntity
    {
        public Holiday Holiday { get; private set; }
        public Employee Employee { get; private set; }
        public Employee Manager { get; private set; }
        public StatusApplication Status { get; private set; }
        public string Message { get; private set; }
        public DateTime StartDay { get; private set; }
        public DateTime EndDay { get; private set; }

        private HolidayApplication()
        {
        }

        public static HolidayApplication Create(Holiday holiday,
                                                Employee employee,
                                                DateTime startDay,
                                                DateTime endDay)
        {
            return new HolidayApplication 
            {
                Id = Guid.NewGuid(),
                Holiday = holiday,
                Employee = employee,
                StartDay = startDay,
                EndDay = endDay,
                Status = StatusApplication.Active
            };
        }

        public StatusApplication SetStatus(StatusApplication status)
        {
            this.Status = status;
            return this.Status;
        }

        public Employee SetManager(Employee manager)
        {
            this.Manager = manager;
            return this.Manager;
        }

        public string SetMessage(string message)
        {
            this.Message = message;
            return this.Message;
        }
    }
}
