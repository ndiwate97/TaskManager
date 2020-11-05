using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    class SubTaskRepository : IRepository<SubTask>
    {
        private TaskManagerDBContext _dbContext;
        public SubTaskRepository()
        {
            _dbContext = new TaskManagerDBContext();
        }
        public Guid Add(SubTask entity)
        {
            Guid guid = _dbContext.SubTasks.Add(entity).Id;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Delete(Guid entityId)
        {
            SubTask subTask = GetById(entityId);
            _dbContext.SubTasks.Remove(subTask);
            _dbContext.SaveChanges();
        }


        public IQueryable<SubTask> Get()
        {
            return _dbContext.SubTasks;
        }

        public SubTask GetById(Guid entityId)
        {
           return _dbContext.SubTasks.Find(entityId);
        }

        public void Update(SubTask entity)
        {
            _dbContext.SubTasks.AddOrUpdate(entity);
        }
    }
}
