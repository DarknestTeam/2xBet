using _2xBet.BLL.DTO;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Services
{
     public class CardService:ICardService
    {
        IUnitOfWork db;

        public CardService(IUnitOfWork unit)
        {
            db = unit;
        }

        public void AddCard (CardDTO cardDTO)
        {
            if (cardDTO == null)
            {
                throw new ValidationException("пожалуйста заполните данные о карточке", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<CardDTO,Card>());
            Card card = Mapper.Map<CardDTO, Card>(cardDTO);
            db.Cards.Create(card);
            db.Save();
        }
        public void UpdateCard(CardDTO cardDTO)
        {
            Card creditcard = db.Cards.Get(cardDTO.CardId);
            if(creditcard == null)
            {
                throw new ValidationException("данная карточка не найдена или пуста", "");
            }
            Mapper.Initialize(cfg => cfg.CreateMap<Card,CardDTO>());
            Card card = Mapper.Map<CardDTO,Card>(cardDTO);
            db.Cards.Update(card);
            db.Save();
        }

        public CardDTO GetCard(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id карточки", "");
            var card = db.Cards.Get(id.Value);
            if (card == null)
                throw new ValidationException("карточка не найдена", "");
            Mapper.Initialize(cfg => cfg.CreateMap<Card,CardDTO>());
            CardDTO cardDTO = Mapper.Map<Card, CardDTO>(card);
            return cardDTO;
            
        }

        public void DeleteCard(int? id)
        {
            if (id == null)
                throw new ValidationException("не найдена карточка с данным id", "");
            else if (db.Cards.Get(id.Value) == null)
                throw new ValidationException("не найдена карточка", "");
            else
                db.Cards.Delete(id);
        }
        public void Dispose()
        {
            db.Dispose();
        }
    }
}
