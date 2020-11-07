using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.Controllers;
using TaskManagerWebAPI.DTOModels;

namespace TaskManagerWebAPI.Service
{
    public class LoginService
    {
        private IRepository<LoginCredential> _loginRepo;

        public LoginService(IRepository<LoginCredential> loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public LoginCredential GetLoginCredential(LoginCredentialDTO credential)
        {
            var creds = _loginRepo.Get();
            return creds.Where(login => login.UserName == credential.UserName && login.Password == credential.Password).SingleOrDefault();
        }

        public LoginCredential GetLoginCredentialById(Guid userId)
        {
            return _loginRepo.GetById(userId);
        }

        public void UpdatePassword(LoginCredential loginCredential)
        {
            _loginRepo.Update(loginCredential);
        }
    }
}