using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;

namespace TaskManagerWebAPI.Service
{
    public class SubTaskService
    {
        private IRepository<SubTask> _subTaskRepo;

        public SubTaskService(IRepository<SubTask> repo)
        {
            _subTaskRepo = repo;
        }

        public IQueryable<SubTask> GetAllSubTask(Guid taskId)
        {
            return _subTaskRepo.Get().Where(subTask=> subTask.TaskId == taskId);
        }

        public SubTask GetSubTaskById(Guid id)
        {
            return _subTaskRepo.GetById(id);
        }

        public Guid AddNewSubTask(SubTask task)
        {
            return _subTaskRepo.Add(task);
        }

        public void UpdateSubTask(SubTask task)
        {
            _subTaskRepo.Update(task);
        }

        public void DeleteSubTask(Guid id)
        {
            _subTaskRepo.Delete(id);
        }

    }
}