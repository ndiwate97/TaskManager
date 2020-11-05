using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repositories
{
    public interface IRepository<T> where T : class
    {

        IQueryable<T> Get();
        T GetById(Guid id);

        Guid Add(T entity);
        void Update(T entity);
        void Delete(Guid entityId);

        IQueryable<T> Find(Expression<Func<T, bool>> specification);

    }
}
