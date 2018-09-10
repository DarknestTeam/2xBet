using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Entities
{
    class Bet
    {
        public int Bet_Id { get; set; }
        public int MatchId { get; set; }
        public int UserId { get; set; }
        public int Amount { get; set; }
        public string Choise { get; set; }
        public DateTime Date { get; set; }
        public string Result { get; set; }
    }
}
