using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
  public  interface IMatchService
    {
        void CreateMatch(MatchDTO match);
        MatchDTO GetMatch(int? id);
        void DeleteMatch(int? id);
        void ChangeMatch(MatchDTO match);

    }
}
