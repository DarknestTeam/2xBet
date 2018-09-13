using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
     public class EFUnitOfWork:IUnitOfWork
    {
        private MainDbContext db;
        private BetRepository betrepos;
        private CardRepository cardrepos;
        private CoefficentRepository coeffrepos;
        private MatchRepository matchrepos;
        private UserRepository userrepos;
        
        // Update
        public  IRepository <Card> Cards => cardrepos= cardrepos == null? (cardrepos = new CardRepository(db)): (cardrepos);
        public IRepository<Match> Matches => matchrepos = matchrepos == null ? (matchrepos= new MatchRepository(db)): (matchrepos);
        public IRepository<User>  Users => userrepos =  userrepos == null ? (userrepos = new UserRepository(db)): (userrepos);
        public IRepository<Coefficent>  Coefficents => coeffrepos = coeffrepos == null ?(coeffrepos = new CoefficentRepository(db)): (coeffrepos);
        public IRepository<Bet> Bets => betrepos = betrepos ==  null ? (betrepos = new BetRepository(db)) : (betrepos);

        public EFUnitOfWork(string connectionString)
        {
            db = new MainDbContext(connectionString);
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
