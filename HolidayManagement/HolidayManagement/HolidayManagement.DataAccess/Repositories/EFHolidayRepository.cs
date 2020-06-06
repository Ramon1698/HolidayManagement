using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.DataAccess.Repositories
{
    public class EFHolidayRepository : EFBaseRepository<Holiday>, IHolidayRepository
    {
        public EFHolidayRepository(HolidayManagementDbContext dbContext) : base(dbContext)
        {
        }
    }
}
