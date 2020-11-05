using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerWebAPI.DTOModels
{
    public class RegisterDTO
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DOB { get; set; }
        public string City { get; set; }
        public long ContactNumber { get; set; }
        public string Email { get; set; }
        public string UserPass { get; set; }
    }
}