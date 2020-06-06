using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Services
{
    public class HolidayService
    {
        private readonly IHolidayRepository holidayRepository;

        public HolidayService(IHolidayRepository holidayRepository)
        {
            this.holidayRepository = holidayRepository;
        }

        public Holiday GetById(Guid id)
        {
            return this.holidayRepository.GetById(id);
        }

        public IEnumerable<Holiday> GetAll()
        {
            return this.holidayRepository.GetAll();
        }

        public Holiday Add(string type, int days, string description)
        {
            var holidayToAdd = Holiday.Create(type, days, description);
            return this.holidayRepository.Add(holidayToAdd);
        }

        public Holiday Update(Guid id, string type, int days, string description)
        {
            var holidayToUpdate = this.holidayRepository.GetById(id);
            holidayToUpdate.Update(type, days, description);
            return this.holidayRepository.Update(holidayToUpdate);
        }

        public void Remove(Guid id)
        {
            var holidayToRemove = this.holidayRepository.GetById(id);
            this.holidayRepository.Remove(holidayToRemove);
        }

    }
}
