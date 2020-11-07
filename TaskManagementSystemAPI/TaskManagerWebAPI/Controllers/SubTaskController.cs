using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user/{userId}/task/{taskId}/subTask")]
    public class SubTaskController : ApiController
    {
        private SubTaskService _subTaskService;
        private MainTaskService _mainTaskService;
        private UserService _userService;
        public SubTaskController(SubTaskService subTaskService, MainTaskService service, UserService userservice)
        {
            _subTaskService = subTaskService;
            _mainTaskService = service;
            _userService = userservice;
        }

        [Route("")]
        public IHttpActionResult Get(Guid userId, Guid taskId)
        {
            if (_userService.GetUserById(userId) == null || _mainTaskService.GetTaskById(taskId) == null)
                return NotFound();


            var subTasks = _subTaskService.GetAllSubTask(taskId).Select(subTask =>
            new SubTaskDTO()
            {
                Id = subTask.TaskId,
                SubTaskName = subTask.SubTaskName,
                Description = subTask.Description,
                StartDateTime = subTask.StartDateTime,
                Status = subTask.Status,
            }).ToList();

            return Ok(subTasks);
        }

        [Route("{SubTaskId}")]
        public IHttpActionResult GetById(Guid subTaskId)
        {
            SubTask task = _subTaskService.GetSubTaskById(subTaskId);
            if (task == null)
                return NotFound();

            SubTaskDTO taskDTO = new SubTaskDTO()
            {
                Id = task.TaskId,
                SubTaskName = task.SubTaskName,
                Description = task.Description,
                StartDateTime = task.StartDateTime,
                Status = task.Status,
            };

            return Ok(taskDTO);

        }


        [Route("AddSubTask")]
        public IHttpActionResult AddSubTask(Guid userId, Guid taskId, SubTaskDTO newSubTask)
        {
            if (_userService.GetUserById(userId) == null || _mainTaskService.GetTaskById(taskId) == null)
                return NotFound();

            SubTask task = new SubTask()
            {
                SubTaskName = newSubTask.SubTaskName,
                Description = newSubTask.Description,
                StartDateTime = newSubTask.StartDateTime,
                Status = newSubTask.Status,
                TaskId  = taskId
            };

            Guid id = _subTaskService.AddNewSubTask(task);

            return Ok(id);
        }

        [Route("UpdateSubTask/{subTaskId}")]
        public IHttpActionResult PutUpdateSubTask(Guid subTaskId, Guid taskId, SubTaskDTO taskDTO)
        {

            SubTask task = _subTaskService.GetSubTaskById(subTaskId);
            if (task == null)
                return NotFound();

            task = new SubTask()
            {
                SubTaskId = subTaskId,
                SubTaskName = taskDTO.SubTaskName,
                Description = taskDTO.Description,
                StartDateTime = taskDTO.StartDateTime,
                Status = taskDTO.Status,
                TaskId = taskId
            };

            _subTaskService.UpdateSubTask(task);

            return Ok(subTaskId);
        }

        [Route("DeleteSubTask")]
        public IHttpActionResult DELETE(Guid subTaskId)
        {
            SubTask task = _subTaskService.GetSubTaskById(subTaskId);
            if (task == null)
                return BadRequest("Task Id is wrong");

            _subTaskService.DeleteSubTask(subTaskId);
            return Ok(subTaskId);
        }


    }

}