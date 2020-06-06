using HolidayManagement.ApplicationLogic.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace HolidayManagement.DataAccess
{
    public class HolidayManagementDbContext : DbContext
    {
        public HolidayManagementDbContext(DbContextOptions<HolidayManagementDbContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<HolidayApplication> HolidayApplications { get; set; }
    }
}
