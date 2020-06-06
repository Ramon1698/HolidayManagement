using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Services
{
    public class HolidayApplicationService
    {
        private readonly IHolidayApplicationRepository holidayApplicationRepository;
        private readonly IEmployeeRepository employeeRepository;
        private readonly IHolidayRepository holidayRepository;

        public HolidayApplicationService(IHolidayApplicationRepository holidayApplicationRepository,
                                         IEmployeeRepository employeeRepository,
                                         IHolidayRepository holidayRepository)
        {
            this.holidayApplicationRepository = holidayApplicationRepository;
            this.holidayRepository = holidayRepository;
            this.employeeRepository = employeeRepository;
        }

        public HolidayApplication GetById(Guid id)
        {
            return this.holidayApplicationRepository.GetById(id);
        }

        public IEnumerable<HolidayApplication> GetAll()
        {
            return this.holidayApplicationRepository.GetAll();
        }

        public IEnumerable<HolidayApplication> GetAllForEmployee(Guid id)
        {
            return this.holidayApplicationRepository.GetAllForEmployee(id);
        }

        public HolidayApplication Add(Guid holidayId, string userId, DateTime startDay, DateTime endDay)
        {
            var holidayDb = this.holidayRepository.GetById(holidayId);
            var employeeDb = this.employeeRepository.GetByUserId(userId);
            var holidayApplicationToAdd = HolidayApplication.Create(holidayDb, employeeDb, startDay, endDay);
            return this.holidayApplicationRepository.Add(holidayApplicationToAdd);
        }
    }
}
