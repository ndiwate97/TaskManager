using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using TaskManagerCore.Models;
using TaskManagerWebAPI.DTOModels;
using TaskManagerWebAPI.Service;

namespace TaskManagerWebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/v1/login")]
    public class LoginController : ApiController
    {
        private LoginService _loginService;
        private UserService _userService;
        public LoginController(LoginService loginService, UserService userService)
        {
            _loginService = loginService;
            _userService = userService;
        }

        [Route("")]
        public IHttpActionResult Login(LoginCredentialDTO credential)
        {
            LoginCredential loginCredential = _loginService.GetLoginCredential(credential);

            if (loginCredential == null)
            {
                return BadRequest("Invalid Credentials");
            }

            return Ok(loginCredential.Id);

        }

        [Route("EmailVerification/{email}")]
        public IHttpActionResult PostResetPass(string email)
        {
            var user = _userService.GetAllUser().Where(u => u.Email == email).SingleOrDefault();
                        
            if (user == null)
            {
                return BadRequest("Invalid Email Id");
            }

            return Ok(user.UserId);
        }

        [Route("ResetPassword/{userId}")]
        public IHttpActionResult Put(Guid userId, PasswordDTO newPassword)
        {
            LoginCredential loginCredential = _loginService.GetLoginCredentialById(userId);

            if (loginCredential == null)
                return NotFound();

            loginCredential.Password = newPassword.Password;
            _loginService.UpdatePassword(loginCredential);
            return Ok();
        }
    }
}