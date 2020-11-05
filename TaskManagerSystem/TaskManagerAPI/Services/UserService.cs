using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repositories;

namespace TaskManagerAPI.Services
{
    public class UserService //: IServices<User>
    {
        private static UserService serviceObj = null;
        private IRepository<User> repository;

        public static UserService getInstance(IRepository<User> repository)
        {
            if (serviceObj == null)
            {
                serviceObj = new UserService(repository);
            }
            return serviceObj;
        }

        public UserService(IRepository<User> repository)
        {
            this.repository = repository;
        }

        //Get List of all Users
        public IQueryable<User> Get()
        {
            return repository.Get();
        }
        //Get user by id
        public User GetById(Guid id)
        {
            return repository.GetById(id);
        }
        //Register new User
        public Guid Add(User entity)
        {
            return repository.Add(entity);
        }
        //delete  existing user
        public void Delete(Guid id)
        {
            repository.Delete(id);
        }
        //Edit existing user
        public void Update(User entity)
        {
            repository.Update(entity);
        }

        public bool IsValidId(Guid id)
        {
            foreach (var u in repository.Get())
            {
                if (u.Id == id)
                    return true;
            }
            return false;
        }
    }
}