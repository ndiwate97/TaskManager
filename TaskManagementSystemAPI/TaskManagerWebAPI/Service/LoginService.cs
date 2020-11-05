using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;
using TaskManagerCore.Repository;
using TaskManagerWebAPI.Controllers;

namespace TaskManagerWebAPI.Service
{
    public class LoginService
    {
        private IRepository<LoginCredential> _loginRepo;

        public LoginService(IRepository<LoginCredential> loginRepo)
        {
            _loginRepo = loginRepo;
        }

        public IQueryable<LoginCredential> GetAllLoginCredential()
        {
            return _loginRepo.Get();
        }

        public LoginCredential GetLoginCredentialById(Guid id)
        {
            return _loginRepo.GetById(id);
        }

        public Guid AddNewLoginCredential(LoginCredential login)
        {
            return _loginRepo.Add(login);
        }

        public void UpdateLoginCredential(LoginCredential login)
        {
            _loginRepo.Update(login);
        }

        public void DeleteLoginCredential(Guid id)
        {
            _loginRepo.Delete(id);
        }
    }
}