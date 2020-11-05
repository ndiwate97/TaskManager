using System;
using System.ComponentModel.DataAnnotations.Schema;


namespace TaskManagerCore.Models
{
    public class LoginCredential
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public User User { get; set; }
    }
}
