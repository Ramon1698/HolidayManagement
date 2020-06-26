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

        public IEnumerable<HolidayApplication> GetAllForEmployee(string userId)
        {
            var employeeDb = this.employeeRepository.GetByUserId(userId);
            return this.holidayApplicationRepository.GetAllForEmployee(employeeDb.Id);
        }

        public IEnumerable<HolidayApplication> GetAllForEmployee(Guid id)
        {
            return this.holidayApplicationRepository.GetAllForEmployee(id);
        }

        public HolidayApplication Add(Guid holidayId,
                                      string userId,
                                      DateTime startDay,
                                      DateTime endDay,
                                      string reasons)
        {
            var holidayDb = this.holidayRepository.GetById(holidayId);
            var employeeDb = this.employeeRepository.GetByUserId(userId);
            var holidayApplicationToAdd = HolidayApplication.Create(holidayDb, employeeDb, startDay, endDay, reasons);
            return this.holidayApplicationRepository.Add(holidayApplicationToAdd);
        }

        public void Cancel(Guid id)
        {
            var holidayApplicationToCancel = GetById(id);
            this.holidayApplicationRepository.Remove(holidayApplicationToCancel);
        }

        public IEnumerable<HolidayApplication> GetAllActive()
        {
            return this.holidayApplicationRepository.GetAllActive();
        }

        public void Accept(Guid id)
        {
            var holidayApplicationToAccept = GetById(id);
            var employee = holidayApplicationToAccept.Employee;
            var holidayDays = holidayApplicationToAccept.EndDay.Subtract(holidayApplicationToAccept.StartDay);
            employee.UpdateConsumedHolidayDays(holidayDays.Days + 1);
            this.employeeRepository.Update(employee);
            holidayApplicationToAccept.SetStatus(StatusApplication.Accepted);
            this.holidayApplicationRepository.Update(holidayApplicationToAccept);
        }

        public void Reject(Guid id)
        {
            var holidayApplicationToAccept = GetById(id);
            holidayApplicationToAccept.SetStatus(StatusApplication.Declined);
            this.holidayApplicationRepository.Update(holidayApplicationToAccept);
        }
    }
}
