using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using TaskManagerCore.DBContext;
using TaskManagerCore.Repositories;
using TaskManagerCore.Models;
using System.Linq.Expressions;

namespace TaskManagerCore.EntityFrameworkRepositories
{
    public class EFUserRepository : IRepository<User>
    {
        private TaskManagerDbContext taskManagerDB;

        public EFUserRepository(TaskManagerDbContext taskManagerDB)
        {
            this.taskManagerDB = taskManagerDB;
        }

        //Get List of all Users
        public IQueryable<User> Get()
        {
            return taskManagerDB.Users;
        }
        //Get user by id
        public User GetById(Guid id)
        {
            foreach (User u in taskManagerDB.Users)
            {
                if (u.Id == id)
                {
                    return u;
                }
            }
            return null;
        }
        //Register new User
        public Guid Add(User entity)
        {
            taskManagerDB.Users.Add(entity);
            taskManagerDB.Credentials.Add(entity.Credentials);
            taskManagerDB.SaveChanges();
            return entity.Id;

        }

        //Edit existing user
        public void Update(User entity)
        {
            taskManagerDB.Users.AddOrUpdate(entity);
            taskManagerDB.SaveChanges();
        }

        //Delete existing user
        public void Delete(Guid entityId)
        {
            try
            {

                User u = GetById(entityId);

                taskManagerDB.Users.Remove(u);
                taskManagerDB.SaveChanges();

            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
                throw new Exception("Record does not exist in the database");
            }

        }

        public IQueryable<User> Find(Expression<Func<User, bool>> specification)
        {
            //return lisofContacts = User.Search(c => c.PhoneNo == 12345)
            throw new NotImplementedException();
        }
    }
}
