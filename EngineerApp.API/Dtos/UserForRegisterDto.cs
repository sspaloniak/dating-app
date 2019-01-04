using System;
using System.ComponentModel.DataAnnotations;
using EngineerApp.API.Models;

namespace EngineerApp.API.Dtos
{
    public class UserForRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int TypePermission { get; set; }
        [Required]
        public string Login { get; set; } 
        [Required]
        [StringLength(8, MinimumLength = 4, ErrorMessage = "You must specify password between 4 and 8 characters.")]
        public string Password { get; set; } 
        public string Superior {get; set;}
        public int IdSuperior {get; set;}
        public string Department { get; set; }
        public int IdDepartment { get; set; }
        public string Email { get; set; }
    }
}