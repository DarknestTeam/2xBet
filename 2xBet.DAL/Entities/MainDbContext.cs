using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Entities
{
    class MainDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Coefficent> Coefficentes { get; set; }
        public DbSet<Bet> Bets { get; set; }
    }
}
