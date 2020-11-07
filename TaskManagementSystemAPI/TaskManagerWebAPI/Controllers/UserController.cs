using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [RoutePrefix("api/v1/user")]
    public class UserController : ApiController
    {
        private UserService _userService;
        
        public UserController(UserService userservice)
        {
           _userService = userservice;
        }

        [Route("")]
        public IHttpActionResult Get()
        {
            var users = _userService.GetAllUser().Select(user =>
            new UserDTO()
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email,
            }).ToList() ;

            return Ok(users);
        }


        [Route("{UserId}")]
        public IHttpActionResult GetById(Guid id)
        {
            User user = _userService.GetUserById(id);
            if (user == null)
                return NotFound();

            UserDTO userDTO = new UserDTO()
            {
                Id = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                DOB = user.DOB,
                City = user.City,
                ContactNumber = user.ContactNumber,
                Email = user.Email
            };

            return Ok(userDTO);

        }


        [Route("Register")]
        public IHttpActionResult RegisterUser(RegisterDTO register)
        {
            LoginCredential creds = new LoginCredential()
            {
                UserName = register.FirstName="_"+register.LastName,
                Password = register.UserPass
            };
            User user = new User()
            {
                FirstName = register.FirstName,
                LastName = register.LastName,
                DOB = register.DOB,
                City = register.City,
                ContactNumber = register.ContactNumber,
                Email = register.Email,
                LoginCredential = creds
            };
            

            Guid id = _userService.AddNewUser(user);

            return Ok(id);
        }

        [Route("UpdateUser")]
        public IHttpActionResult PutUpdateUser(Guid userId, UserDTO userDTO)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return NotFound();

            user.FirstName = userDTO.FirstName;
            user.LastName = userDTO.LastName;
            user.DOB = userDTO.DOB;
            user.City = userDTO.City;
            user.ContactNumber = userDTO.ContactNumber;
            user.Email = userDTO.Email;
            user.LoginCredential.UserName = userDTO.Email;
            _userService.UpdateUser(user);

            return Ok(userId);
        }


        [Route(""), ResponseType(typeof(Guid))]
        public IHttpActionResult DELETE(Guid userId)
        {
            User user = _userService.GetUserById(userId);
            if (user == null)
                return BadRequest("User Id is wrong");

            _userService.DeleteUser(userId);
            return Ok(userId);
        }
    }
}
