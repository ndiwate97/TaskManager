using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TaskManagerCore.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string ProfilePicture { get; set; }
        public List<UserTask> UserTasks { get; set; }
        public LoginCredentials Credentials { get; set; }

        public User()
        {
            UserTasks = new List<UserTask>();
        }
    }
}
