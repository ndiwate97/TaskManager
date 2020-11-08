using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
        public IHttpActionResult Get(Guid userId)
        {            
            if (_userService.GetUserById(userId) == null)
            {
                return NotFound();
            }

            var tasks = _mainTaskService.GetAllTask(userId).Select(task =>
            new MainTaskDTO()
            {
                Id = task.TaskId,
                TaskName = task.TaskName,
               Description = task.Description,
               StartDateTime= task.StartDateTime,
               Status = task.Status,
               //userId = task.User.Id
            }).ToList();

            return Ok(tasks);
        }


        [Route("{taskId}")]
        public IHttpActionResult GetById(Guid taskId)
        {
            MainTask task = _mainTaskService.GetTaskById(taskId);
            if (task == null)
                return NotFound();

            MainTaskDTO taskDTO = new MainTaskDTO()
            {
                Id = task.TaskId,
                TaskName = task.TaskName,
                Description = task.Description,
                StartDateTime = task.StartDateTime,
                Status = task.Status,
                //userId = task.User.Id
            };

            return Ok(taskDTO);

        }


        [Route("AddTask")]
        public IHttpActionResult AddTask(Guid userId, MainTaskDTO newTask)
        {
            if (_userService.GetUserById(userId) == null)
                return NotFound();

            MainTask task = new MainTask()
            {
                TaskName = newTask.TaskName,
                Description = newTask.Description,
                StartDateTime = newTask.StartDateTime,
                Status = newTask.Status,
                UserId = userId        
            };

            Guid id = _mainTaskService.AddNewTask(task);

            return Ok(id);
        }

        [Route("UpdateTask/{taskId}")]
        public IHttpActionResult PutUpdateTask( Guid taskId, Guid userId, MainTaskDTO taskDTO)
        {

            MainTask task = _mainTaskService.GetTaskById(taskId);
            if (task == null)
                return NotFound(); 

            task = new MainTask()
            {
                TaskId = taskId,
                TaskName = taskDTO.TaskName,
                Description = taskDTO.Description,
                StartDateTime = taskDTO.StartDateTime,
                Status = taskDTO.Status,
                UserId = userId
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
