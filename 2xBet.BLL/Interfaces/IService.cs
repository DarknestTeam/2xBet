using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
  public  interface IService<T>where T:class
    {
        void Add(T item);
        IEnumerable<T> GetItems();
        void Update(T item);
        void Delete(int id);
        
        void Dispose();
    }
}
