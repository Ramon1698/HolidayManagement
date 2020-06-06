using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Services
{
    public class EmployeeService
    {
        private readonly IEmployeeRepository employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public Employee GetById(Guid id)
        {
            return this.employeeRepository.GetById(id);
        }

        public Employee GetByUserId(string userId)
        {
            return this.employeeRepository.GetByUserId(userId);
        }

        public IEnumerable<Employee> GetAll()
        {
            return this.employeeRepository.GetAll();
        }

        public Employee Add(string userId,
                            string name,
                            string email,
                            string phone,
                            int holidayDays)
        {
            var employeeToAdd = Employee.Create(userId, name, email, phone, holidayDays);
            return this.employeeRepository.Add(employeeToAdd);
        }

        public Employee Update(Guid id,
                               string name,
                               string email,
                               string phone,
                               int holidayDays)
        {
            var employeeToUpdate = this.employeeRepository.GetById(id);
            employeeToUpdate.Update(name, email, phone, holidayDays);
            return this.employeeRepository.Update(employeeToUpdate);
        }

        public void Remove(Guid id)
        {
            var employeeToRemove = this.employeeRepository.GetById(id);
            this.employeeRepository.Remove(employeeToRemove);
        }
    }
}
