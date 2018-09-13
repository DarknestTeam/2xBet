using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Entities
{
     public class Coefficent
    {
        public string CommandCoeff_Id { get; set; }
        public string CoeffWin { get; set; }
        public string CoeffLose { get; set; }
        public string CoeffDraw { get; set; }
        public int MatchId { get; set; }
    }
}
