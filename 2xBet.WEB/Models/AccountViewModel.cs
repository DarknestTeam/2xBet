using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace _2xBet.WEB.Models
{
    public class RegisterViewModel
    {
        public int User_Id { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        [MinLength(6, ErrorMessage = "Не менее 6 символов")]
        [MaxLength(50, ErrorMessage = "Не более 50 символов")]
        public string Login { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Не менее 6 символов")]
        [MaxLength(50, ErrorMessage = "Не более 50 символов")]
        public string Password { get; set; }
        public string CardId { get; set; }
    }
    public class LoginViewModel
    {
        public int User_Id { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
    }
}