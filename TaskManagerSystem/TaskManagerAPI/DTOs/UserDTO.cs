using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TaskManagerAPI.DTOs
{
    public class UserDTO
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public string Pin { get; set; }
        public DateTime Dob { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string ProfilePicture { get; set; }
    }
}