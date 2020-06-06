using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayManagement.DataAccess.Repositories
{
    public class EFEmployeeRepository : EFBaseRepository<Employee>, IEmployeeRepository
    {
        public EFEmployeeRepository(HolidayManagementDbContext dbContext) : base(dbContext)
        {
        }

        public Employee GetByUserId(string userId)
        {
            return dbContext.Employees.Where(employee => employee.UserId == userId).SingleOrDefault();
        }
    }
}
