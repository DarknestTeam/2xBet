using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
    public  interface IBetService
    {
        void CraeateBet(BetDTO betDTO);
        void Delete(int Id);
        BetDTO Get(int id);
        IEnumerable<BetDTO> Bets();
        void ChangeBet(BetDTO betDTO);
    }
}
