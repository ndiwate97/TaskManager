using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerCore.Models
{
    public class LoginCredentials
    {
        [ForeignKey("User")]
        public Guid Id { get; set; }
        public User User { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}