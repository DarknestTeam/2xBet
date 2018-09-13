using _2xBet.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Interfaces
{
     public interface IUserService
    {
        void MakeUser(UserDTO userDTO);
        UserDTO Get(int? id);
        void UpdateUser(UserDTO user);
        void Delete(int? id);
        void DepositAccount(int? id, float amount);
        void AddCard(CardDTO card);
    }
}
