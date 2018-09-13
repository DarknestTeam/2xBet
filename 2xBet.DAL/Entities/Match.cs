using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Entities
{
    public class Match
    {
        public int Match_Id { get; set; }
        public bool IsLive { get; set; }
        public string TypeOfSport { get; set; }
        public DateTime Time { get; set; }
        public string League { get; set; }
    }
}
