using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.Controllers;

namespace TaskManagerWebAPI.Service
{
    public class MainTaskService
    {
        private IRepository<MainTask> _mainTaskRepo;

        public MainTaskService(IRepository<MainTask> repo)
        {
            _mainTaskRepo = repo;
        }

        public IQueryable<MainTask> GetAllTask(Guid userId)
        {
            return _mainTaskRepo.Get().Where(mainTask => mainTask.UserId == userId);
        }

        public MainTask GetTaskById(Guid id)
        {
            return _mainTaskRepo.GetById(id);
        }

        public Guid AddNewTask(MainTask task)
        {
            return _mainTaskRepo.Add(task);
        }

        public void UpdateTask(MainTask task)
        {
            _mainTaskRepo.Update(task);
        }

        public void DeleteTask(Guid id)
        {
            _mainTaskRepo.Delete(id);
        }

    }
}