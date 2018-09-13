using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
    class AbstractRepository<T>:IRepository<T> where T:class,new()
    {
        MainDbContext db;

        protected AbstractRepository(MainDbContext context)
        {
            this.db = context;
        }
        public T Get(int? id)
        {
            return db.Set<T>().Find(id);
        }
        public IEnumerable<T> GetAll()
        {
            return db.Set<T>();
        }
        public void Create(T t)
        {
            db.Set<T>().Add(t);
        }
        public void Update (T t)
        {
            db.Entry(t).State = System.Data.Entity.EntityState.Modified;
        }
        //public IEnumerable<T>Find(Func<T,Boolean>predicate)
        //{
        //    return db.Set<T>().Find()
        //}
        public void Delete (int? id)
        {
            T t = db.Set<T>().Find(id);
            if (t != null)
                db.Set<T>().Remove(t);
        }
    }
}
