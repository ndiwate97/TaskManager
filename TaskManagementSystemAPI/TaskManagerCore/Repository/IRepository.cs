using System;
using System.Linq;
using System.Linq.Expressions;

namespace TaskManagerCore.Repository
{
    public interface IRepository<T> where T : class
    {
        Guid Add(T entity);
        void Update(T entity);
        void Delete(Guid entityId);
        IQueryable<T> Get();
        T GetById(Guid entityId);
        IQueryable<T> Find(Expression<Func<T, bool>> specification);
    }
}
