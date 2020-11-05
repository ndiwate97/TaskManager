using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user/{userId}/task")]
    public class TaskController : ApiController
    {
        private MainTaskService _mainTaskService;
        private UserService _userService;

        public TaskController(MainTaskService service, UserService userservice) {
            _mainTaskService = service;
            _userService = userservice;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var tasks = _mainTaskService.GetAllTask().Select(task =>
            new MainTaskDTO()
            {
                Id = task.Id,
                TaskName = task.TaskName,
               Description = task.Description,
               StartDateTime= task.StartDateTime,
               Status = task.Status,
               userId = task.User.Id
            }).ToList();

            return Ok(tasks);
        }


        [Route("{taskId}")]
        public IHttpActionResult GetById(Guid id)
        {
           MainTask task = _mainTaskService.GetTaskById(id);
            if (task == null)
                return NotFound();

            MainTaskDTO taskDTO = new MainTaskDTO()
            {
                Id = task.Id,
                TaskName = task.TaskName,
                Description = task.Description,
                StartDateTime = task.StartDateTime,
                Status = task.Status,
                userId = task.User.Id
            };

            return Ok(taskDTO);

        }


        [Route("AddTask")]
        public IHttpActionResult AddTask(MainTaskDTO newTask)
        {

            MainTask task = new MainTask()
            {
                TaskName = newTask.TaskName,
                Description = newTask.Description,
                StartDateTime = newTask.StartDateTime,
                Status = newTask.Status,
                User = _userService.GetUserById(newTask.userId)        
            };


            Guid id = _mainTaskService.AddNewTask(task);

            return Ok(id);
        }

        [Route("UpdateTask")]
        public IHttpActionResult PutUpdateTask(Guid taskId, MainTaskDTO taskDTO)
        {

            MainTask task = new MainTask()
            {
                Id = taskId,
                TaskName = taskDTO.TaskName,
                Description = taskDTO.Description,
                StartDateTime = taskDTO.StartDateTime,
                Status = taskDTO.Status,
                User = _userService.GetUserById(taskDTO.userId)
            };

            _mainTaskService.UpdateTask(task);

            return Ok(taskId);
        }


        [Route("DeleteTask")]
        public IHttpActionResult DELETE(Guid taskId)
        {
            MainTask task = _mainTaskService.GetTaskById(taskId);
            if (task == null)
                return BadRequest("Task Id is wrong");

            _mainTaskService.DeleteTask(taskId);
            return Ok(taskId);
        }
    }
}
