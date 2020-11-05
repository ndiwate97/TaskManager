using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class UserRepository : IRepository<User>
    {
        private TaskManagerDBContext _dbContext;
        public UserRepository(TaskManagerDBContext context)
        {
            //_dbContext = new TaskManagerDBContext();
            _dbContext = context;
        }

        public IQueryable<User> Get()
        {
            return _dbContext.Users.Include("LoginCredential");
        }

        public User GetById(Guid entityId)
        {
            return _dbContext.Users.Include("LoginCredential").Where(u => u.Id == entityId).FirstOrDefault();
        }

        public Guid Add(User entity)
        {
            Guid guid = _dbContext.Users.Add(entity).Id;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Update(User entity)
        {
            _dbContext.Users.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid entityId)
        {
            User user = _dbContext.Users.SingleOrDefault(u => u.Id == entityId);
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public IQueryable<User> Find(Expression<Func<User, bool>> specification)
        {
            throw new NotImplementedException();
        }

    }
}
