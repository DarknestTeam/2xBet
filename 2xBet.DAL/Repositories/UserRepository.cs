using _2xBet.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.DAL.Repositories
{
    class UserRepository:AbstractRepository<User>
    {
        public UserRepository(MainDbContext context):base(context)
        { }
    }
}
