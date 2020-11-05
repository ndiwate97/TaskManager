using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TaskManagerCore.Models;

namespace TaskManagerWebAPI.DTOModels
{
    public class UserDTO
    {
        public Guid Id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide First Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "First Name Should be min 5 and max 20 length")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Last Name")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Last Name Should be min 5 and max 20 length")]
        public string LastName { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime DOB { get; set; }

        public string City { get; set; }

        [Required(ErrorMessage = "Please provide a phone number")]
        [RegularExpression(@"^(\+\d{1,3}[- ]?)?\d{10}$", ErrorMessage = "Not a valid phone number")]
        public long ContactNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Provide Email id")]
        public string Email { get; set; }

    }
}