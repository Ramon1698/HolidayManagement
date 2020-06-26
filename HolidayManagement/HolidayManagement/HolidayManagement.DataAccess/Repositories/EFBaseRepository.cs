using HolidayManagement.ApplicationLogic.Abstractions;
using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HolidayManagement.DataAccess.Repositories
{
    public class EFBaseRepository<T> : IBaseRepository<T> where T : DataEntity
    {
        protected readonly HolidayManagementDbContext dbContext;

        public EFBaseRepository(HolidayManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public T Add(T entity)
        {
            dbContext.Add<T>(entity);
            dbContext.SaveChanges();
            return entity;
        }

        public IEnumerable<T> GetAll()
        {
            return dbContext.Set<T>().AsEnumerable();
        }

        public virtual T GetById(Guid id)
        {
            return dbContext.Set<T>().Where(entity => entity.Id == id).SingleOrDefault();
        }

        public void Remove(T entity)
        {
            dbContext.Remove<T>(entity);
            dbContext.SaveChanges();
        }

        public T Update(T entity)
        {
            dbContext.Update<T>(entity);
            dbContext.SaveChanges();
            return entity;
        }
    }
}
