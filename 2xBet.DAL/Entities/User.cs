using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Entities
{
     public class User
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
        public float  Account { get; set; }
        public string CardId { get; set; }
        public Card Card { get; set; }
    }
}
