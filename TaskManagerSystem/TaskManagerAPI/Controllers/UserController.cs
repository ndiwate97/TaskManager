using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TaskManagerAPI.DTOs;
using TaskManagerAPI.Services;
using TaskManagerCore.DBContext;
using TaskManagerCore.EntityFrameworkRepositories;
using TaskManagerCore.Models;

namespace TaskManagerAPI.Controllers
{
    [RoutePrefix("api/v1/User")]
    public class UserController : ApiController
    {
        //IServices<User> userService;
        UserService userService;

        //public UserController(UserService userService)
        //{
        //    this.userService = userService;
        //}

        [Route("")]
        public IQueryable<User> Get()
        {
            return userService.Get();
        }

        [Route("{id:Guid}")]
        public User GetByID(Guid id)
        {
            return userService.GetById(id);
        }

        [Route("Register")]
        public IHttpActionResult RegisterUser(RegisterDTO user)
        {
            LoginCredentials credentials = new LoginCredentials
            {
                Password = user.Password,
                Role = user.Role
            };

            User newUser = new User
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                ContactNo = user.ContactNo,
                Email = user.Email,
                City = user.City,
                Pin = user.Pin,
                Credentials = credentials
            };

            userService.Add(newUser);

            return Ok("User Added Successfully");
        }

        [Route("{id:Guid}/UpdateUser")]
        public IHttpActionResult PutUpdateUser(Guid id, UserDTO user)
        {
            User updatedUser = new User
            {
                Id = id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Dob = user.Dob,
                ContactNo = user.ContactNo,
                Email = user.Email,
                City = user.City,
                Pin = user.Pin,
                ProfilePicture = user.ProfilePicture,
            };

            userService.Update(updatedUser);

            return Ok("User Updated Successfully");
        }

        [Route("DeleteUser")]
        public IHttpActionResult Delete(Guid id)
        {

            UserService userService = UserService.getInstance(new EFUserRepository(new TaskManagerDbContext()));

            // return BadRequest("Bad req abc");
            // new EFUserRepository(new TaskManagerDbContext());
            User u = userService.GetById(id);
            if (u == null)
            {
                return NotFound();
            }
            else
            {
                userService.Delete(id);
                //userService.Delete(u);
                return Ok("user Deleted Successfully");
            }
        }

    }
}