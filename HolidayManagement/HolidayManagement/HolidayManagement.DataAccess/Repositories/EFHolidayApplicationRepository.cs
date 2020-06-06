using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayManagement.DataAccess.Repositories
{
    public class EFHolidayApplicationRepository : EFBaseRepository<HolidayApplication>, IHolidayApplicationRepository
    {
        public EFHolidayApplicationRepository(HolidayManagementDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<HolidayApplication> GetAllForEmployee(Guid id)
        {
            return dbContext.HolidayApplications.Where(ha => ha.Employee.Id == id);
        }
    }
}
