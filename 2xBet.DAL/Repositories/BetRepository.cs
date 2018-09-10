using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
    class BetRepository : AbstractRepository<Bet>
    {
       

        public BetRepository(MainDbContext context):base(context)
        {
            
        }
      
    }
}
