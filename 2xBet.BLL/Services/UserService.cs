﻿using _2xBet.BLL.DTO;
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
        ICardService card { get; set; }
        public UserService(IUnitOfWork uow,ICardService card)
        {

            Db = uow;
            this.card = card;

        }
       
        public void AddCard(CardDTO cardDTO)
        {

            card.AddCard(cardDTO);
            
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
                Db.Save();
            }
        }

        public void DepositAccount(int? id, float amount)
        {
            User user = Db.Users.Get(id);
            if (id == null)
            {
                throw new ValidationException("Не введене сумма ", "");
            }
            else if(user == null)
            {
                throw new ValidationException("Данный пользователь не найден", "");
            }
            user.Account += amount;
            Db.Users.Update(user);
            Db.Save();

        }


        public UserDTO Get(int? id)
        {

            User user = Db.Users.Get(id);
            if (id == null)
            {
                throw new ValidationException("Не установлен Id пользователя", "");
            }
            else if (user == null)
            {
                throw new ValidationException("Данный пользователь не найден", "");
            }
            else
            { 
                Mapper.Initialize(cfg => cfg.CreateMap<User, UserDTO>());
                UserDTO userDTO = Mapper.Map<User, UserDTO>(user);
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

            Db.Users.Update(user);
            Db.Save();

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
        public void Dispose()
        {
            Db.Dispose();
        }
    }
}
