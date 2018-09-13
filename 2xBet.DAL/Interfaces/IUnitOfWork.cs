using _2xBet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Bet>Bets { get; }
        IRepository<Card>Cards { get; }
        IRepository<Coefficent>Coefficents { get; }
        IRepository<Match> Matches { get; }
        IRepository<User> Users { get; }
        void Save();

    }
}
