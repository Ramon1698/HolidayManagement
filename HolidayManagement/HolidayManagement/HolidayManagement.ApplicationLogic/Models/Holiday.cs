using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Models
{
    public class Holiday : DataEntity
    {
        public string Type { get; private set; }
        public int Days { get; private set; }
        public string Description { get; private set; }

        private Holiday()
        {
        }

        public static Holiday Create(string type, int days, string description)
        {
            return new Holiday
            {
                Id = Guid.NewGuid(),
                Type = type,
                Days = days,
                Description = description
            };
        }

        public Holiday Update(string type, int days, string description)
        {
            this.Type = type;
            this.Days = days;
            this.Description = description;
            return this;
        }
    }
}
