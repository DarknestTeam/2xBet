using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.DTO
{
   public class CardDTO
    {
        public int CardId { get; set; }
        [Required]
        [DataType(DataType.CreditCard)]
        public string NumberCard { get; set; }
        [Required]
        [MaxLength(5, ErrorMessage = "формат должен быть : 01/21")]
        public string Term { get; set; }
        [Required]
        [MaxLength(20, ErrorMessage = "не более 20 букв")]
        public string CardHolderName { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "не более 3 символов кода")]
        public string Code { get; set; }
    }
}
