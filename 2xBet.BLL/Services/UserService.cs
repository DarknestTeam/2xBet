using _2xBet.BLL.DTO;
using _2xBet.DAL.Entities;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;


namespace _2xBet.BLL.Services
{
    public class UserService : IUserService
    {
        IUnitOfWork Db { get; set; }
        public void AddCard(CardDTO card)
        {
            throw new NotImplementedException();
        }

        public void Delete(int? id)
        {

            if (id == null)
            {
                throw new ValidationException("Не установлен Id пользователя", "");
            }
            else if ((Db.Users.Get(id)) == null)
            {
                throw new ValidationException("Данный пользователь не найден", "");
            }
            else
            {
                Db.Users.Delete(id);
            }



        }

        public void DepositAccount(UserDTO userDTO, int id)
        {
            if (id == null)
            {
                throw new ValidationException("Не введене сумма ", "");
            }
            else if ((Db.Users.Get(id)) == null)
            {
                throw new ValidationException("Данный пользователь не найден", "");
            }
            
        }

        public UserDTO Get(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Не установлен Id пользователя", "");
            }
            else if ((Db.Users.Get(id)) == null)
            {
                throw new ValidationException("Данный пользователь не найден", "");
            }
            else
            {
                UserDTO userDTO = new UserDTO();//=  new MapperConfiguration(cfg => cfg.CreateMap<User, UserDTO>()).CreateMapper();
                return userDTO;
                 
            }
        }

        public void MakeUser(UserDTO userDTO)
        {
            if (userDTO == null)
            {
                throw new ValidationException("Данные о пользователе отсутствуют ", "");
            }
            User user = new User
            {
                User_Id = userDTO.User_Id,
                Login = userDTO.Login,
                Password = userDTO.Password,
                Email = userDTO.Email,
                Card = null,
                CardId = null
               
            };

             
           
        }

        public void UpdateUser(UserDTO userDTO)
        {
            User user = Db.Users.Get(userDTO.User_Id);
            if (user == null)
            {
                throw new ValidationException("Данные о пльзователе отсутствуют", "");
            }
            else if (user == null)
            {

                throw new ValidationException("Данный пользователь не найден", "");
            }
            else
            {
                user = new User
                {
                    User_Id = userDTO.User_Id,
                    Login = userDTO.Login,
                    Password = userDTO.Password,
                    Email = userDTO.Email,
                    Card = null,
                    CardId = userDTO.CardId
                };
                Db.Users.Create(user);
                Db.Save();
            }
        }
    }
}
