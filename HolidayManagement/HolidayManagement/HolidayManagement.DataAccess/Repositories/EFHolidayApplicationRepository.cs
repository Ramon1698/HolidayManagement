using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
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

        public IEnumerable<HolidayApplication> GetAllActive()
        {
            return dbContext.HolidayApplications.Where(ha => ha.Status == StatusApplication.Active)
                .Include(ha => ha.Holiday)
                .Include(ha => ha.Employee);
        }

        public IEnumerable<HolidayApplication> GetAllForEmployee(Guid id)
        {
            return dbContext.HolidayApplications
                .Include(ha => ha.Holiday)
                .Include(ha => ha.Employee)
                .Where(ha => ha.Employee.Id == id);
        }

        public override HolidayApplication GetById(Guid id)
        {
            return dbContext.HolidayApplications
                .Include(ha => ha.Holiday)
                .Include(ha => ha.Employee)
                .Where(ha => ha.Id == id)
                .SingleOrDefault();
        }
    }
}
