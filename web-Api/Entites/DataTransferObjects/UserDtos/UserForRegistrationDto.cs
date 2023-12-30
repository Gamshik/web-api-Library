﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObjects.UserDtos
{
    public class UserForRegistrationDto
    {
        [Required(ErrorMessage = "First name is required!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last name is required!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "User name is required!")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
