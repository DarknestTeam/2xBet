using _2xBet.BLL.DTO;
using _2xBet.BLL.Infrastructure;
using _2xBet.BLL.Interfaces;
using _2xBet.DAL.Entities;
using _2xBet.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2xBet.BLL.Services
{
    class CardService:ICardService
    {
        IUnitOfWork db;

        public CardService(IUnitOfWork unit)
        {
            db = unit;
        }

        public void AddCard (CardDTO card)
        {
            if (card == null)
            {
                throw new ValidationException("пожалуйста заполните данные о карточке", "");
            }
            Card creditcard = new Card
            {
                CardHolderName = card.CardHolderName,
                CardId = card.CardId,
                Code = card.Code,
                NumberCard = card.Term,
                Term = card.Term
            };
            db.Cards.Create(creditcard);
            db.Save();
        }
        public void UpdateCard(CardDTO card)
        {
            Card creditcard = db.Cards.Get(card.CardId);
            if(creditcard == null)
            {
                throw new ValidationException("данная карточка не найдена или пуста", "");
            }
            creditcard = new Card
            {
                CardHolderName = card.CardHolderName,
                CardId = card.CardId,
                Code = card.Code,
                NumberCard = card.Term,
                Term = card.Term
            };
            db.Cards.Create(creditcard);
            db.Save();
        }
        public CardDTO GetCard(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлен id карточки", "");
            var card = db.Cards.Get(id.Value);
            if (card == null)
                throw new ValidationException("карточка не найдена", "");
            return new CardDTO { CardHolderName = card.CardHolderName, CardId = card.CardId, Code = card.Code, NumberCard = card.NumberCard, Term = card.Term };
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
    }
}
