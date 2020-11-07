using System;
using System.Collections.Generic;

namespace TaskManagerCore.Models
{
    public class User
    {
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
        public LoginCredential LoginCredential { get; set; }
        public ICollection<MainTask> Task { get; set; }

        public User()
        {
            UserId = Guid.NewGuid();
        }
    }
}
