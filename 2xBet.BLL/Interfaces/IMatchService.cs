using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
   public interface IMatchService
    {
        void CreateMatch(MatchDTO match);
        void DeleteMatch(int? id);
        void UpdateMatch(MatchDTO match);
        MatchDTO GetMatch(MatchDTO match);
        IEnumerable<MatchDTO> matches();
        Boolean IsLive(int id);

    }
}
