using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerAPI.Services
{
    public interface IServices<T> where T : class
    {
        IQueryable<T> Get();
        T GetById(Guid id);

        Guid Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool IsValidId(Guid id);
    }
}