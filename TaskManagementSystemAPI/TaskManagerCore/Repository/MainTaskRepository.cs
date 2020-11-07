using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using TaskManagerCore.DBContext;
using TaskManagerCore.Models;

namespace TaskManagerCore.Repository
{
    public class MainTaskRepository : IRepository<MainTask>
    {
        private TaskManagerDBContext _dbContext;
        public MainTaskRepository(TaskManagerDBContext context)
        {
            _dbContext = context;
        }

        public IQueryable<MainTask> Get()
        {
            return _dbContext.MainTasks;
        }

        public MainTask GetById(Guid entityId)
        {
            return _dbContext.MainTasks.Include("SubTask").Where(t => t.TaskId == entityId).FirstOrDefault();
        }

        public Guid Add(MainTask entity)
        {
            Guid guid = _dbContext.MainTasks.Add(entity).TaskId;
            _dbContext.SaveChanges();
            return guid;
        }

        public void Update(MainTask entity)
        {
            _dbContext.MainTasks.AddOrUpdate(entity);
            _dbContext.SaveChanges();
        }

        public void Delete(Guid entityId)
        {
            MainTask task = _dbContext.MainTasks.SingleOrDefault(t => t.TaskId == entityId);
            _dbContext.MainTasks.Remove(task);
            _dbContext.SaveChanges();
        }

    }
}
