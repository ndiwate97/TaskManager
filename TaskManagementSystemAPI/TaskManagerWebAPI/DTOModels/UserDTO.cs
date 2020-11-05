using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;

namespace TaskManagerWebAPI.DTOModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
    }
}