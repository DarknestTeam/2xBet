using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
    class EFUnitOfWork:IUnitOfWork
    {
        private MainDbContext db;
        private BetRepository betrepos;
        private CardRepository cardrepos;
        private CoefficentRepository coeffrepos;
        private MatchRepository matchrepos;
        private UserRepository userrepos;

        public EFUnitOfWork(string connectionString)
        {
            db = new MainDbContext(connectionString);
        }
        public IRepository<Bet> Bets
        {
            get
            {
                if (betrepos == null)
                    betrepos = new BetRepository(db);
                return betrepos;
            }
        }
        public IRepository<Card> Cards
        {
            get
            {
                if (cardrepos == null)
                    cardrepos = new CardRepository(db);
                return cardrepos;
            }
        }
        public IRepository<Coefficent> Coefficents
        {
            get
            {
                if (coeffrepos == null)
                   coeffrepos = new CoefficentRepository(db);
                return coeffrepos;
            }
        }
        public IRepository<Match> Matches
        {
            get
            {
                if (matchrepos == null)
                    matchrepos = new MatchRepository(db);
                return matchrepos;
            }
        }
        public IRepository<User> Users
        {
            get
            {
                if (userrepos == null)
                    userrepos = new UserRepository(db);
                return userrepos;
            }
        }
        public void Save()
        {
            db.SaveChanges();
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
