using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
   public interface ICardService
    {
        
        CardDTO GetCard(int? id);
        void DeleteCard(int? id);
        void UpdateCard(CardDTO card);


    }
}
