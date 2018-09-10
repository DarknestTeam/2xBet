using _2xBet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
    class MatchRepository:AbstractRepository<Match>
    {
        public MatchRepository(MainDbContext context):base(context)
        { }
    }
}
