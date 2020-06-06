using HolidayManagement.ApplicationLogic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HolidayManagement.ApplicationLogic.Abstractions
{
    public interface IBaseRepository<T> where T : DataEntity
    {
        T Add(T entity);
        T Update(T entity);
        void Remove(T entity);
        T GetById(Guid id);
        IEnumerable<T> GetAll();
    }
}
